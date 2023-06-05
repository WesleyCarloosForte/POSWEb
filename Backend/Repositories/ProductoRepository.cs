using Backend.Data;
using SharedProject.Interface;
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

        public async Task<IEnumerable<Producto>> GetProductosWithDataFilter(Func<Producto, bool> condiction = null)
        {
            if (condiction==null)
                return await _context.Productos.Include(x=>x.Categoria).ToListAsync(); 
            else
                return  _context.Productos.Include(x => x.Categoria).Where(condiction).ToList();

        }

        public  async Task<Producto> GetProductoWithData(int id)
        {
            return await _context.Productos.Include(c => c.Categoria).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IEnumerable<Producto>> GetProductosWithDataInStock(Func<Producto, bool> condiction = null)
        {
            if (condiction==null)
            return await _context.Productos.Include(x => x.Categoria).Where(x => x.StockActual > 0).ToListAsync();

            return  _context.Productos.Include(x => x.Categoria).Where(x => x.StockActual > 0).ToList();
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


        async Task<Producto> IProductoRepository.GetProductoWithDataInStock(Func<Producto, bool> condiction)
        {
            return  _context.Productos.Where(condiction).Where(x=>x.StockActual>0).FirstOrDefault();
        }
    }
}
