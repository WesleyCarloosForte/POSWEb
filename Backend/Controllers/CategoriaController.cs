using Microsoft.AspNetCore.Mvc;
using SharedProject.Models;
using Backend.Repositories;
using SharedProject.Interface;
using SharedProject.DTOs;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository repository,IMapper mapper)
        {
            _mapper= mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaViewDTO>> GetAll()
        {
            try
            {
                var categorias = _repository.GetAll();

                var result = _mapper.Map<IEnumerable<CategoriaViewDTO>>(categorias);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("filter/{txt}")]
        public async Task< ActionResult<IEnumerable<CategoriaViewDTO>>> GetAll(string txt)
        {
            try
            {
                var result =  await _repository.FilterGet(txt);

               

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult<CategoriaViewDTO> GetById(int id)
        {
            try
            {
                var categoria = _repository.GetById(id);
                var result = _mapper.Map<CategoriaViewDTO>(categoria);
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<CategoriaViewDTO> Create(CategoriaCreateDTO categoria)
        {
            try
            {
                var categoria_ = _mapper.Map<Categoria>(categoria);
                _repository.Add(categoria_);

                var retorno = _mapper.Map<CategoriaViewDTO>(categoria_);

                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoriaCreateDTO categoria)
        {
            try
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
                var categoria = _repository.GetById(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _repository.Delete(categoria);
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
