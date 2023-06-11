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
        public async Task<IEnumerable<KardexProducto>> GetProductoWithDataKardex(int id)
        {
           return await _context.KardexProductos.Include(x=>x.Producto).ThenInclude(x=>x.Categoria).Where(x => x.ProductoId == id).ToListAsync();
        }

        public async Task AddAsync(Producto producto, int action)
        {
            Producto item = new Producto();
            var kardex = new KardexProducto();
            kardex.Fecha = DateTime.Now;
            kardex.Valor = producto.PrecioVenta;
            kardex.ValorCompra = producto.PrecioCompra;
            kardex.NumeroComprobante = "Ninguno";
            kardex.Tipo = "Registro/Edicion";
            kardex.TipoComprobante = "Ninguno";
            kardex.GananciaEsperada = Convert.ToInt32(producto.PrecioVenta - producto.PrecioCompra);
            if (action == 0)
            {
                

                

                kardex.CantidadMovimiento = Convert.ToInt32(producto.StockActual);
                kardex.stockActual = Convert.ToInt32(producto.StockActual);
                kardex.stockAnterior = 0;
                kardex.Descripcioin = "Registro de producto";
                

            }
            else
            {

                 item = await _context.Productos?.FirstOrDefaultAsync(x => x.Id == producto.Id);

                kardex.CantidadMovimiento = Convert.ToInt32(producto.StockActual- item.StockActual);
                kardex.stockActual = Convert.ToInt32(producto.StockActual);
                kardex.stockAnterior = Convert.ToInt32(item.StockActual);
                kardex.Descripcioin = "Edicion de producto";
                kardex.ProductoId= producto.Id;
                item.Descripcion = producto.Descripcion;
                item.CategoriaId = producto.CategoriaId;
                item.CodigoBarras= producto.CodigoBarras;
                item.PrecioCompra= producto.PrecioCompra;
                item.PrecioVenta= producto.PrecioVenta;
                item.PrecioCompra=producto.PrecioCompra;
                item.StockActual= producto.StockActual;
                item.StockMinimo= producto.StockMinimo;

                _context.Update(item);
                _context.Update(kardex);
                //    _context.Entry(item).State = EntityState.Modified;
                  //  _context.Entry(kardex).State = EntityState.Modified;


            }
            try
            {
                
                await _context.SaveChangesAsync();

                if (action == 0)
                {
                    await _context.Productos.AddAsync(producto);

                    await _context.SaveChangesAsync();
                    kardex.ProductoId = producto.Id;
                    await _context.KardexProductos.AddAsync(kardex);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
