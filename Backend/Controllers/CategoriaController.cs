using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using Backend.Interface;
using SharedProject.DTOs;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CategoriaController(IRepository<Categoria> repository,IMapper mapper)
        {
            _mapper= mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaViewDTO>> GetAll()
        {
            var categorias = _repository.GetAll();

            var result = _mapper.Map<IEnumerable<CategoriaViewDTO>>(categorias);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaViewDTO> GetById(int id)
        {
            var categoria = _repository.GetById(id);
            var result = _mapper.Map<CategoriaViewDTO>(categoria);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<CategoriaViewDTO> Create(CategoriaCreateDTO categoria)
        {
            var categoria_=_mapper.Map<Categoria>(categoria);
            _repository.Add(categoria_);

            var retorno = _mapper.Map<CategoriaViewDTO>(categoria_);

            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoriaCreateDTO categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            var existingCategoria = _repository.GetById(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            existingCategoria.Descripcion = categoria.Descripcion;

            _repository.Update(existingCategoria);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _repository.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _repository.Delete(categoria);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
