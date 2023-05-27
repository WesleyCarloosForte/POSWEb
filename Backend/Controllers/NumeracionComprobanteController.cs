using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using Backend.Interface;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeracionComprobanteController : ControllerBase
    {
        private readonly INumeracionComprobanteRepository _repository;

        public NumeracionComprobanteController(INumeracionComprobanteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NumeracionComprobante>> GetAll()
        {
            var numeraciones = _repository.GetAll();
            return Ok(numeraciones);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<NumeracionComprobante>> GetById(int id)
        {
            var numeracion = _repository.GetById(id);
            if (numeracion == null)
            {
                return NotFound();
            }
            return Ok(numeracion);
        }

        [HttpPost]
        public ActionResult<IEnumerable<NumeracionComprobante>> Create(NumeracionComprobante numeracion)
        {
            _repository.Add(numeracion);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = numeracion.Id }, numeracion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, NumeracionComprobante numeracion)
        {
            if (id != numeracion.Id)
            {
                return BadRequest();
            }

            var existingNumeracion = _repository.GetById(id);
            if (existingNumeracion == null)
            {
                return NotFound();
            }

            existingNumeracion.Descripcion = numeracion.Descripcion;
            existingNumeracion.NumeroActual = numeracion.NumeroActual;
            existingNumeracion.NumeroFinal = numeracion.NumeroFinal;
            existingNumeracion.InicioVigencia = numeracion.InicioVigencia;
            existingNumeracion.FinVigencia = numeracion.FinVigencia;
            existingNumeracion.ValorFiscal = numeracion.ValorFiscal;
            existingNumeracion.Timbrado = numeracion.Timbrado;
            existingNumeracion.Establecimiento = numeracion.Establecimiento;
            existingNumeracion.PuntoExpedicion = numeracion.PuntoExpedicion;
            existingNumeracion.Estado = numeracion.Estado;

            _repository.Update(existingNumeracion);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var numeracion = _repository.GetById(id);
            if (numeracion == null)
            {
                return NotFound();
            }

            _repository.Delete(numeracion);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
