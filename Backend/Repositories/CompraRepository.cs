using Backend.Data;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SharedProject.DTOs;

namespace Backend.Repositories
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly DataContext _context;
        public CompraRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Compra compra)
        {

            

            foreach(var item in compra.DetallesCompra)
            {
                var unitatio = item.TotalCompra / item.Cantidad;
                item.PrecioCompraUnitario= unitatio;
                var r = await _context.Productos.FirstOrDefaultAsync(x=>x.Id==item.ProductoId);
                r.StockActual += item.Cantidad;
                r.PrecioCompra = unitatio;

                item.PrecioCompraUnitario = r.PrecioVenta;

                await _context.KardexProductos.AddAsync(new KardexProducto
                {
                    CantidadMovimiento = Convert.ToInt32(item.Cantidad),
                    Descripcioin = "Compra",
                    Fecha = DateTime.Now,
                    PrecioUnitario=unitatio,
                    GananciaEsperada = (r.PrecioVenta - unitatio)*item.Cantidad,
                    GananciaUnitaria= r.PrecioVenta - unitatio,
                    NumeroComprobante = $"{compra.NumeroComprobante}",
                    ProductoId = item.ProductoId,
                    stockActual = Convert.ToInt32(r.StockActual) ,
                    stockAnterior = Convert.ToInt32(r.StockActual + item.Cantidad),
                    Valor = r.PrecioVenta*item.Cantidad,
                    Tipo = "Ingreso",
                    TipoComprobante = $"Comprobante de compra",
                    ValorCompra = r.PrecioCompra
                });

                _context.Entry(r).State=EntityState.Modified;
            }



            await _context.Compras.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Compra>> GetComprasWithData(Func<Compra,bool> action=null)
        {
            if (action == null)
            {
                return await _context.Compras.Include(x=>x.Proveedor).ThenInclude(x=>x.DatosGenerales)
                       .Include(x => x.DetallesCompra)
                        .ThenInclude(dt => dt.Producto).ThenInclude(x=>x.Categoria).Take(10)
                         .ToListAsync();
            }
            else
            {
                return  _context.Compras.Include(x => x.Proveedor).ThenInclude(x => x.DatosGenerales)
                .Include(x => x.DetallesCompra)
                .ThenInclude(dt => dt.Producto).ThenInclude(x => x.Categoria).Where(action ).Take(10)
                .ToList();
            }


            

        }

        public async Task<Compra?> GetComprasWithData(int id)
        {
            var a = await _context.Compras.Include(x => x.Proveedor).ThenInclude(x => x.DatosGenerales)
                .Include(x => x.DetallesCompra)
                .ThenInclude(dt => dt.Producto)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            return a;
        }
    }
}
