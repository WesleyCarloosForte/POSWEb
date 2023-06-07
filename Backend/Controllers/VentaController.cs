using AutoMapper;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _VentaRepository;
        private readonly IMapper _mapper;
        private readonly Data.DataContext _context;

        public VentaController(IVentaRepository compraRepository, IMapper mapper,Data.DataContext context)
        {
            _VentaRepository = compraRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaViewDTO>>> GetCompras()
        {
            var ventas = await _VentaRepository.GetComprasWithData(null);

            var c2 = (from c in ventas
                      select new VentaViewDTO
                      {
                         DetallesVenta  = (from d in c.DetallesVenta
                                           select new DetalleVentaViewDTO
                                           {
                                               Cantidad = d.Cantidad,
                                               CodigoBarras = d.CodigoBarras,
                                               VentaId = d.VentaId,
                                               Id = d.Id,
                                               PrecioVenta = d.PrecioVenta,
                                               PrecioCompra= d.PrecioCompra,
                                               Descuento= d.Descuento,
                                               TotalVenta=d.TotalVenta,
                                               Producto = d.Producto.Descripcion,
                                               ProductoId = d.ProductoId,
                                               TotalCompra = d.TotalCompra
                                           }).ToList(),
                          Estado=c.Estado,
                          Fecha=c.Fecha,
                          Id=c.Id,
                          NumeroComprobante = c.NumeroComprobante,
                          ClienteId=c.ClienteId,
                          Cliente=c.Cliente,
                          Comprobante=c.Comprobante,
                          ComprobanteId=c.ComprobanteId,
                          Establecimiento=c.Establecimiento,
                          PuntoExpedicion =c.PuntoExpedicion,
                          Timbrado=c.Timbrado,
                          TotalCompra= c.TotalCompra
                       
                      });


            var comprasDTO = c2;
    


            return Ok(comprasDTO);
        }



        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<VentaViewDTO>>> GetComprasFilter(string txt)
        {
            var ventas = await _VentaRepository.GetComprasWithData(x=>($"{x.Establecimiento}-{x.PuntoExpedicion}-{x.NumeroComprobante}").Contains(txt));

            var c2 = (from c in ventas
                      select new VentaViewDTO
                      {
                          DetallesVenta = (from d in c.DetallesVenta
                                           select new DetalleVentaViewDTO
                                           {
                                               Cantidad = d.Cantidad,
                                               CodigoBarras = d.CodigoBarras,
                                               VentaId = d.VentaId,
                                               Id = d.Id,
                                               PrecioVenta = d.PrecioVenta,
                                               PrecioCompra = d.PrecioCompra,
                                               Descuento = d.Descuento,
                                               TotalVenta = d.TotalVenta,
                                               Producto = d.Producto.Descripcion,
                                               ProductoId = d.ProductoId,
                                               TotalCompra = d.TotalCompra
                                           }).ToList(),
                          Estado = c.Estado,
                          Fecha = c.Fecha,
                          Id = c.Id,
                          NumeroComprobante = c.NumeroComprobante,
                          ClienteId = c.ClienteId,
                          Cliente = c.Cliente,
                          Comprobante = c.Comprobante,
                          ComprobanteId = c.ComprobanteId,
                          Establecimiento = c.Establecimiento,
                          PuntoExpedicion = c.PuntoExpedicion,
                          Timbrado = c.Timbrado,
                          TotalCompra = c.TotalCompra

                      });


            var comprasDTO = c2;



            return Ok(comprasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentaViewDTO>> GetCompra(int id)
        {
            var venta = await _VentaRepository.GetComprasWithData(id);
            if (venta == null)
            {
                return NotFound();
            }

            var c2 =  
                       new VentaViewDTO
                      {
                          DetallesVenta = (from d in venta.DetallesVenta
                                           select new DetalleVentaViewDTO
                                           {
                                               Cantidad = d.Cantidad,
                                               CodigoBarras = d.CodigoBarras,
                                               VentaId = d.VentaId,
                                               Id = d.Id,
                                               PrecioVenta = d.PrecioVenta,
                                               PrecioCompra = d.PrecioCompra,
                                               Descuento = d.Descuento,
                                               TotalVenta = d.TotalVenta,
                                               Producto = d.Producto.Descripcion,
                                               ProductoId = d.ProductoId,
                                               TotalCompra = d.TotalCompra
                                           }).ToList(),
                          Estado = venta.Estado,
                          Fecha = venta.Fecha,
                          Id = venta.Id,
                          NumeroComprobante = venta.NumeroComprobante,
                          ClienteId = venta.ClienteId,
                          Cliente = venta.Cliente,
                          Comprobante = venta.Comprobante,
                          ComprobanteId = venta.ComprobanteId,
                          Establecimiento = venta.Establecimiento,
                          PuntoExpedicion = venta.PuntoExpedicion,
                          Timbrado = venta.Timbrado,
                          TotalCompra = venta.TotalCompra

                      };


            var comprasDTO = c2;
            return Ok(c2);
        }

        [HttpPost]
        public async Task<ActionResult<VentaViewDTO>> Create(CreateVentaDTO compraCreateDTO)
        {
            try
            {
                var venta = _mapper.Map<Venta>(compraCreateDTO);
                var DetalleCompra = _mapper.Map<List<DetalleVenta>>(compraCreateDTO.DetallesVenta);

                venta.DetallesVenta = DetalleCompra;

                await _VentaRepository.AddAsync(venta);



                var compraDTO = _mapper.Map<VentaViewDTO>(venta);
                return Ok(compraDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var venta = _VentaRepository.GetById(id);
                if (venta == null)
                {
                    return NotFound();
                }

                venta.Estado = false;
                _VentaRepository.Update(venta);

                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            if (id==null)
            {
                return BadRequest();
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var venta = await _VentaRepository.GetComprasWithData(id);
            if (venta == null)
            {
                return NotFound();
            }
            venta.Estado = false;

            foreach (var item in venta.DetallesVenta)
            {

                var r = _context.Productos.FirstOrDefault(x => x.Id == item.ProductoId);
                r.StockActual -= item.Cantidad;
                _context.Entry(r).State = EntityState.Modified;
                await _context.KardexProductos.AddAsync(new KardexProducto
                {
                    CantidadMovimiento = Convert.ToInt32(item.Cantidad),
                    Descripcioin = "Venta Cancelada",
                    Fecha = DateTime.Now,
                    PrecioUnitario = item.PrecioVenta,
                    GananciaUnitaria = 0,
                    GananciaEsperada = 0,
                    NumeroComprobante = $"{venta.Establecimiento}-{venta.PuntoExpedicion}-{venta.NumeroComprobante}",
                    ProductoId = item.ProductoId,
                    stockActual = Convert.ToInt32(r.StockActual + item.Cantidad),
                    stockAnterior = Convert.ToInt32(r.StockActual),
                    Valor = item.PrecioVenta,
                    Tipo = "Ingreso",
                    TipoComprobante = $"{venta.Comprobante.Descripcion}",
                    ValorCompra = item.PrecioCompra
                });

            }


            _VentaRepository.Update(venta);

           await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
