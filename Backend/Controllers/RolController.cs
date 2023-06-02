using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using SharedProject.Interface;
using SharedProject.DTOs;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _repository;

        public RolController(IRolRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetAll()
        {
            var roles = _repository.GetAll();
            return Ok(roles);
        }
        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<RolViewDTO>>> GetAll(string txt)
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
        public ActionResult<IEnumerable<Rol>> GetById(int id)
        {
            try
            {
                var rol = _repository.GetById(id);
                if (rol == null)
                {
                    return NotFound();
                }
                return Ok(rol);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<IEnumerable<Rol>> Create(Rol rol)
        {
            try
            {
                _repository.Add(rol);
                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = rol.Id }, rol);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Rol rol)
        {
            try
            {
                if (id != rol.Id)
                {
                    return BadRequest();
                }

                var existingRol = _repository.GetById(id);
                if (existingRol == null)
                {
                    return NotFound();
                }

                existingRol.Descripcion = rol.Descripcion;

                _repository.Update(existingRol);
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
                var rol = _repository.GetById(id);
                if (rol == null)
                {
                    return NotFound();
                }

                _repository.Delete(rol);
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
