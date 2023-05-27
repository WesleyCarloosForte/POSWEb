using Backend.Data;
using Backend.Interface;
using SharedProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly DataContext _context;

        public ProductoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductosWithData()
        {
           return await _context.Productos.Include(x=>x.Categoria).ToListAsync(); 
        }

        public  async Task<Producto> GetProductosWithData(int id)
        {
            return await _context.Productos.Include(c => c.Categoria).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IEnumerable<Producto>> GetProductosWithDataInStock()
        {
            return await _context.Productos.Include(x => x.Categoria).Where(x => x.StockActual > 0).ToListAsync();
        }

        public async Task<Producto> GetProductosWithDataInStock(int id)
        {
            return await _context.Productos.Include(c => c.Categoria).Where(x=>x.StockActual>0).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RestarStock(int id,decimal cantidad)
        {
            var result= await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            result.StockActual = -cantidad;
        }

        public async Task SumarStock(int id, decimal cantidad)
        {
            var result = await _context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            result.StockActual = +cantidad;
        }

        Task<Producto> IProductoRepository.GetProductosWithDataInStock()
        {
            throw new NotImplementedException();
        }
    }
}
