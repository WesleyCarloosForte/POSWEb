using SharedProject.DTOs;
using Backend.Interface;
using SharedProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            var productos = _productoRepository.GetProductosWithData();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _productoRepository.GetProductosWithData(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Post([FromBody] ProductoCreateDTO producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            var p = new Producto 
            {
            CategoriaId=producto.CategoriaId,
            CodigoBarras=producto.CodigoBarras,
            Descripcion=producto.Descripcion,
            PrecioCompra=producto.PrecioCompra,
            PrecioVenta= producto.PrecioVenta,
            StockActual=producto.StockActual,
            StockMinimo= producto.StockMinimo
            };
                _productoRepository.Add(p);
            
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductoCreateDTO producto)
        {
            if (producto == null || id != producto.Id)
            {
                return BadRequest();
            }
            var p = new Producto
            {
                Id=producto.Id,
                CategoriaId = producto.CategoriaId,
                CodigoBarras = producto.CodigoBarras,
                Descripcion = producto.Descripcion,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                StockActual = producto.StockActual,
                StockMinimo = producto.StockMinimo
            };

            var existingProducto = _productoRepository.GetById(id);
            if (existingProducto == null)
            {
                return NotFound();
            }

            _productoRepository.Update(p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _productoRepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            _productoRepository.Delete(producto);
            return NoContent();
        }

    }
}
