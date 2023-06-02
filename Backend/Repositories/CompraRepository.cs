using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly DataContext _context;
        public CompraRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Compra>> GetComprasWithData()
        {
            var a = await _context.Compras
            .Include(x => x.DetallesCompra)
            .ThenInclude(dt => dt.Producto)
            .ToListAsync();



            return a;
        }

        public async Task<Compra?> GetComprasWithData(int id)
        {
            var a = await _context.Compras
                .Include(x => x.DetallesCompra)
                .ThenInclude(dt => dt.Producto)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            return a;
        }
    }
}
