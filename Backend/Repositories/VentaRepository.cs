using Backend.Data;
using Backend.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class VentaRepository:Repository<Venta>,IVentaRepository
    {
        private readonly DataContext _context;
        public VentaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> GetComprasWithData()
        {
            var a = await _context.Ventas
                .Include(x=>x.Cliente)
                .Include(x=>x.Comprobante)
             .Include(x=>x.DetallesVenta)
            .ThenInclude(dt => dt.Producto)
            .ToListAsync();



            return a;
        }

        public async Task<Venta> GetComprasWithData(int id)
        {
            var a = await _context.Ventas
                .Include(x => x.Cliente)
                .Include(x => x.Comprobante)
             .Include(x => x.DetallesVenta)
            .ThenInclude(dt => dt.Producto)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            return a;
        }
    }
}
