using AutoMapper;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _VentaRepository;
        private readonly IMapper _mapper;

        public VentaController(IVentaRepository compraRepository, IMapper mapper)
        {
            _VentaRepository = compraRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaViewDTO>>> GetCompras()
        {
            var ventas = await _VentaRepository.GetComprasWithData();

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
            var venta = _mapper.Map<Venta>(compraCreateDTO);
            var DetalleCompra = _mapper.Map<List<DetalleVenta>>(compraCreateDTO.DetallesVenta);

            venta.DetallesVenta = DetalleCompra;

            await _VentaRepository.AddAsync(venta);

            

            var compraDTO = _mapper.Map<VentaViewDTO>(venta);
            return Ok( compraDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id==null)
            {
                return BadRequest();
            }

            var venta =  _VentaRepository.GetById(id);
            if (venta == null)
            {
                return NotFound();
            }

            venta.Estado=false;
            _VentaRepository.Update(venta);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var venta =  _VentaRepository.GetById(id);
            if (venta == null)
            {
                return NotFound();
            }

            _VentaRepository.Delete(venta);

            return NoContent();
        }
    }
}
