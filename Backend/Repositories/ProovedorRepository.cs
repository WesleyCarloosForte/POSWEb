using Backend.Data;
using Backend.Interface;
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

        public async Task<IEnumerable<Proveedor>> GetClientesWithData()
        {
            var a = await _context.Proveedores
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                .ToListAsync();
            return a;
        }

        public async Task<Proveedor> GetClientesWithData(int id)
        {
            return await _context.Proveedores
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();
        }
    }
}
