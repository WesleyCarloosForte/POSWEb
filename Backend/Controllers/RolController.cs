using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using Backend.Interface;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRepository<Rol> _repository;

        public RolController(IRepository<Rol> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetAll()
        {
            var roles = _repository.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Rol>> GetById(int id)
        {
            var rol = _repository.GetById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Rol>> Create(Rol rol)
        {
            _repository.Add(rol);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Rol rol)
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
    }
}
