using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using Backend.Interface;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoRepository _repository;

        public DocumentoController(IDocumentoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Documento>> GetAll()
        {
            var documentos = _repository.GetAll();
            return Ok(documentos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Documento>> GetById(int id)
        {
            var documento = _repository.GetById(id);
            if (documento == null)
            {
                return NotFound();
            }
            return Ok(documento);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Documento>> Create(Documento documento)
        {
            _repository.Add(documento);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = documento.Id }, documento);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Documento documento)
        {
            if (id != documento.Id)
            {
                return BadRequest();
            }

            var existingDocumento = _repository.GetById(id);
            if (existingDocumento == null)
            {
                return NotFound();
            }

            existingDocumento.Descripcion = documento.Descripcion;
            existingDocumento.Estado = documento.Estado;
            existingDocumento.CantidadDigitos = documento.CantidadDigitos;

            _repository.Update(existingDocumento);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var documento = _repository.GetById(id);
            if (documento == null)
            {
                return NotFound();
            }

            _repository.Delete(documento);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
