using Backend.Data;
using Backend.Interface;
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

        public async Task<IEnumerable<Cliente>> GetClientesWithData()
        {
            var a= await _context.Clientes
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                .ToListAsync();
            return a;
        }

        public async Task<Cliente> GetClientesWithData(int id)
        {
            return await _context.Clientes
                .Include(c => c.DatosGenerales)
                .ThenInclude(dg => dg.Documento)
                 .Where(x => x.Id == id)
                 .FirstOrDefaultAsync();
        }
    }


}
