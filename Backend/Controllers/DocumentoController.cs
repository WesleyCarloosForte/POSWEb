using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using SharedProject.Interface;
using SharedProject.DTOs;

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

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<DocumentoViewDTO>>> GetAll(string txt)
        {
            try
            {
                var result = await _repository.FilterGet(txt);



                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Documento>> GetById(int id)
        {
            try
            {
                var documento = _repository.GetById(id);
                if (documento == null)
                {
                    return NotFound();
                }
                return Ok(documento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<IEnumerable<Documento>> Create(Documento documento)
        {
            try
            {
                _repository.Add(documento);
                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = documento.Id }, documento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
         
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Documento documento)
        {
            try
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
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
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
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }
    }
}
