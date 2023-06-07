using Backend.Data;
using SharedProject.Interface;
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

        public async Task AddAsync(Venta venta)
        {

            var productos = new List<Producto>();

            var comprobante = _context.NumeracionComprobantes.FirstOrDefault(x=>x.Id==venta.ComprobanteId);

            comprobante.NumeroActual++;


            venta.Timbrado = comprobante.Timbrado;
            venta.NumeroComprobante = comprobante.NumeroActual.ToString();
            venta.PuntoExpedicion = comprobante.PuntoExpedicion;
            venta.Establecimiento=comprobante.Establecimiento;
            venta.FechaInicio = comprobante.InicioVigencia.GetValueOrDefault();
            venta.FechaFin=comprobante.FinVigencia.GetValueOrDefault();

            _context.Entry(comprobante).State= EntityState.Modified;

            foreach (var item in venta.DetallesVenta)
            {
               

                var r = _context.Productos.FirstOrDefault(x => x.Id == item.ProductoId);
                r.StockActual -= item.Cantidad;
                _context.Entry(r).State= EntityState.Modified;
                await _context.KardexProductos.AddAsync(new KardexProducto
                {
                    CantidadMovimiento = Convert.ToInt32(item.Cantidad),
                    Descripcioin = "Venta",
                    Fecha = DateTime.Now,
                    PrecioUnitario=item.PrecioVenta,
                    GananciaUnitaria=item.PrecioVenta-r.PrecioCompra,
                    GananciaEsperada = item.Cantidad*(item.PrecioVenta -r.PrecioCompra),
                    NumeroComprobante=$"{venta.Establecimiento}-{venta.PuntoExpedicion}-{venta.NumeroComprobante}",
                    ProductoId=item.ProductoId,
                    stockActual=Convert.ToInt32(r.StockActual-item.Cantidad),
                    stockAnterior=Convert.ToInt32(r.StockActual),
                    Valor=item.PrecioVenta,
                    Tipo="Salida",
                    TipoComprobante=$"{comprobante.Descripcion}",
                    ValorCompra=item.PrecioCompra
                }) ;



            }
            await _context.Ventas.AddAsync(venta);

            

            var result = await _context.SaveChangesAsync();

        }


        public async Task<IEnumerable<Venta>> GetComprasWithData(Func<Venta,bool> action =null)
        {
            if (action == null)
            {
                return await _context.Ventas
                    .Include(x => x.Cliente).ThenInclude(x=>x.DatosGenerales)
                    .Include(x => x.Comprobante)
                 .Include(x => x.DetallesVenta)
                .ThenInclude(dt => dt.Producto).Take(10)
                .ToListAsync();
            }
             return  _context.Ventas
                    .Include(x => x.Cliente).ThenInclude(x => x.DatosGenerales)
                    .Include(x => x.Comprobante)
                 .Include(x => x.DetallesVenta)
                .ThenInclude(dt => dt.Producto).Where(action).Take(10)
                .ToList();




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
