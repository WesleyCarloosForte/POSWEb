using AutoMapper;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Data;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ComprasController(ICompraRepository compraRepository, IMapper mapper,DataContext context)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraViewDTO>>> GetCompras()
        {
            var compras = await _compraRepository.GetComprasWithData(null);

            var c2 = (from c in compras
                      select new CompraViewDTO
                      {
                          DetalleCompra = (from d in c.DetallesCompra
                                           select new CompraDetalleView
                                           {
                                               Cantidad = d.Cantidad,
                                               CodigoBarras = d.CodigoBarras,
                                               CompraId = d.CompraId,
                                               Id = d.Id,
                                               PrecioCompraUnitario = d.PrecioCompraUnitario,
                                               Producto = d.Producto.Descripcion,
                                               ProductoId = d.ProductoId,
                                               TotalCompra = d.TotalCompra
                                           }).ToList(),
                          Estado=c.Estado,
                          Fecha=c.Fecha,
                          Id=c.Id,
                          NumeroComprobante = c.NumeroComprobante,
                          Proveedor=c.Proveedor,
                          ProveedorId=c.ProveedorId,
                          TotalCompra= c.TotalCompra
                       
                      });


            var comprasDTO = c2;
    


            return Ok(comprasDTO);
        }

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<CompraViewDTO>>> GetComprasFilter(string txt)
        {
            var compras = await _compraRepository.GetComprasWithData(x=>x.NumeroComprobante.Contains(txt));

            var c2 = (from c in compras
                      select new CompraViewDTO
                      {
                          DetalleCompra = (from d in c.DetallesCompra
                                           select new CompraDetalleView
                                           {
                                               Cantidad = d.Cantidad,
                                               CodigoBarras = d.CodigoBarras,
                                               CompraId = d.CompraId,
                                               Id = d.Id,
                                               PrecioCompraUnitario = d.PrecioCompraUnitario,
                                               Producto = d.Producto.Descripcion,
                                               ProductoId = d.ProductoId,
                                               TotalCompra = d.TotalCompra
                                           }).ToList(),
                          Estado = c.Estado,
                          Fecha = c.Fecha,
                          Id = c.Id,
                          NumeroComprobante = c.NumeroComprobante,
                          Proveedor = c.Proveedor,
                          ProveedorId = c.ProveedorId,
                          TotalCompra = c.TotalCompra

                      });


            var comprasDTO = c2;



            return Ok(comprasDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompraViewDTO>> GetCompra(int id)
        {
            var compra = await _compraRepository.GetComprasWithData(id);
            if (compra == null)
            {
                return NotFound();
            }

            var detalles = (from d in compra.DetallesCompra select new CompraDetalleView { 
                Cantidad = d.Cantidad, 
                CodigoBarras = d.CodigoBarras, 
                CompraId = d.CompraId, 
                Id = d.Id, 
                PrecioCompraUnitario = d.PrecioCompraUnitario, 
                Producto = d.Producto.Descripcion, 
                ProductoId = d.ProductoId, 
                TotalCompra = d.TotalCompra }).ToList();
            var compraDTO = new CompraViewDTO
            {
                TotalCompra = compra.TotalCompra,
                DetalleCompra = detalles,
                Estado = compra.Estado,
                Fecha = compra.Fecha,
                Id = compra.Id,
                NumeroComprobante = compra.NumeroComprobante,
                Proveedor = compra.Proveedor,
                ProveedorId = compra.ProveedorId,
            };
            return Ok(compraDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> Create(CompraCreateDTO compraCreateDTO)
        {
            var compra = _mapper.Map<Compra>(compraCreateDTO);
            var DetalleCompra = _mapper.Map<List<DetalleCompra>>(compraCreateDTO.DetallesCompra);

            compra.NumeroComprobante = compraCreateDTO.NumeroComprobante;

            compra.DetallesCompra = DetalleCompra;

           await _compraRepository.AddAsync(compra);

            return Ok(compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompraCreateDTO compraUpdateDTO)
        {
            if (id != compraUpdateDTO.Id)
            {
                return BadRequest();
            }

            var compra =  _compraRepository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }

            _mapper.Map(compraUpdateDTO, compra);
            _compraRepository.Update(compra);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var compra = await _compraRepository.GetComprasWithData(id);
            if (compra == null)
            {
                return NotFound();
            }
            compra.Estado = false;

            foreach (var item in compra.DetallesCompra)
            {
                var unitatio = item.TotalCompra / item.Cantidad;
                item.PrecioCompraUnitario = unitatio;
                var r = await _context.Productos.FirstOrDefaultAsync(x => x.Id == item.ProductoId);
                r.StockActual += item.Cantidad;
                r.PrecioCompra = unitatio;

                item.PrecioCompraUnitario = r.PrecioVenta;

                await _context.KardexProductos.AddAsync(new KardexProducto
                {
                    CantidadMovimiento = Convert.ToInt32(item.Cantidad),
                    Descripcioin = "Compra Anulada",
                    Fecha = DateTime.Now,
                    PrecioUnitario = unitatio,
                    GananciaEsperada = 0,
                    GananciaUnitaria = 0,
                    NumeroComprobante = $"{compra.NumeroComprobante}",
                    ProductoId = item.ProductoId,
                    stockActual = Convert.ToInt32(r.StockActual),
                    stockAnterior = Convert.ToInt32(r.StockActual - item.Cantidad),
                    Valor = r.PrecioVenta * item.Cantidad,
                    Tipo = "Salida",
                    TipoComprobante = $"Comprobante de compra",
                    ValorCompra = r.PrecioCompra
                });

                _context.Entry(r).State = EntityState.Modified;
            }

            _compraRepository.Update(compra);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
