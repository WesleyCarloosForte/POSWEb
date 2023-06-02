using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class ClienteRepository : Repository<Cliente>,IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesWithData(Func<Cliente, bool> condition = null)
        {
            if (condition == null)
            {
                return await _context.Clientes
                    .Include(c => c.DatosGenerales)
                    .ThenInclude(dg => dg.Documento)
                    .ToListAsync();
            }

            else
            return  _context.Clientes
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                .Where(condition)
                .ToList();
        }

        public async Task<Cliente> GetClientesWithData(int id)
        {
            return await _context.Clientes
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();
        }

        public new void Update(Cliente entity)
        {
            var entityGeneral = new DatosGenerales();

            entityGeneral = entity.DatosGenerales;
            entityGeneral.Id = entity.DatosGeneralesId;

            _context.Entry(entityGeneral).State = EntityState.Modified;
            _context.Entry(entity).State = EntityState.Modified;
             this.SaveChanges();
             return;
            
            throw (new Exception("no fue posible encontrar los datos"));

        }
    }


}
