using AutoMapper;
using SharedProject.DTOs;
using Backend.Interface;
using SharedProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public ComprasController(ICompraRepository compraRepository, IMapper mapper)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraViewDTO>>> GetCompras()
        {
            var compras = await _compraRepository.GetComprasWithData();

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
        public async Task<ActionResult<CompraViewDTO>> Create(CompraCreateDTO compraCreateDTO)
        {
            var compra = _mapper.Map<Compra>(compraCreateDTO);
            var DetalleCompra = _mapper.Map<List<DetalleCompra>>(compraCreateDTO.DetallesCompra);

            compra.DetallesCompra = DetalleCompra;

            _compraRepository.Add(compra);
            var compraDTO = _mapper.Map<CompraCreateDTO>(compra);
            return CreatedAtAction(nameof(GetCompra), new { id = compraDTO.Id }, compraDTO);
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
            var compra =  _compraRepository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }

            _compraRepository.Delete(compra);

            return NoContent();
        }
    }
}
