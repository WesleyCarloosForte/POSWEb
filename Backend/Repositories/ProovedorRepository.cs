using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ProovedorRepository:Repository<Proveedor>,IProveedorRepository
    {
        private readonly DataContext _context;
        public ProovedorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetClientesWithData(Func<Proveedor,bool> condiction = null)
        {
            if (condiction == null) 
            return  await _context.Proveedores
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                .ToListAsync();

            return  _context.Proveedores
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                .Where(condiction)
                .ToList();
        }

        public async Task<Proveedor> GetClientesWithData(int id)
        {
            return await _context.Proveedores
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();
        }

        public new void Update(Proveedor entity)
        {
            var id = entity.DatosGeneralesId;
            var entityGeneral = entity.DatosGenerales;
            entityGeneral.Id = entity.DatosGeneralesId;

           entityGeneral.DocumentoId = entity.DatosGenerales.DocumentoId;
           _context.Entry(entityGeneral).State = EntityState.Modified;
           _context.Entry(entity).State = EntityState.Modified;
                this.SaveChanges();
                return;
            
            throw (new Exception("no fue posible encontrar los datos"));

        }
    }
}
