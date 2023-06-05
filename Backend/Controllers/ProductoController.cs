using SharedProject.DTOs;
using SharedProject.Interface;
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
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await _productoRepository.GetProductosWithDataFilter();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _productoRepository.GetProductoWithData(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }
        [HttpGet("Consultar/{barCode}/{cantidad}")]
        public async Task<ActionResult<bool>> GetbarCode(string barCode, int cantidad)
        {
            var producto = await _productoRepository.GetProductoWithDataInStock(x => x.CodigoBarras == barCode && x.StockActual>=cantidad);

            if (producto == null)
            {
                return Ok(false);
            }

            return Ok(true);
        }
        [HttpGet("barCode/{barCode}")]
        public async Task<ActionResult<Producto>> GetbarCode(string barCode)
        {
            var producto = await _productoRepository.GetProductoWithDataInStock(x => x.CodigoBarras == barCode);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpGet("barCode/Compra/{barCode}")]
        public async Task<ActionResult<Producto>> GetbarCodeCompra(string barCode)
        {
            var producto = await _productoRepository.GetProductosWithDataFilter(x=>x.CodigoBarras== barCode);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto.FirstOrDefault());
        }

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetFilter(string txt)
        {
            var producto = await _productoRepository.GetProductosWithDataFilter(x => x.Descripcion.ToLower().Contains(txt.ToLower()) |x.CodigoBarras.Contains(txt));

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpGet("edit/{id}")]
        public async Task< ActionResult<Producto>> GetEdit(int id)
        {
            var producto = await _productoRepository.GetProductoWithData(id);

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


            var existingProducto = _productoRepository.GetById(id);
            if (existingProducto == null)
            {
                return NotFound();
            }
            existingProducto.CategoriaId = producto.CategoriaId;
            existingProducto.CodigoBarras = producto.CodigoBarras;
            existingProducto.Descripcion = producto.Descripcion;
            existingProducto.PrecioCompra = producto.PrecioCompra;
            existingProducto.PrecioVenta = producto.PrecioVenta;
            existingProducto.StockActual = producto.StockActual;
            existingProducto.StockMinimo = producto.StockMinimo;

            _productoRepository.Update(existingProducto);
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
