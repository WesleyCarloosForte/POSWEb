using AutoMapper;
using Backend.Data;
using SharedProject.DTOs;
using SharedProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// ...

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewDTO>> GetUsuarios()
        {
            var usuarios = _context.Usuarios.Include(u => u.Rol).Include(dt=>dt.DatosGenerales).ThenInclude(dt=>dt.Documento).ToList();
            var usuariosDto = _mapper.Map<List<UsuarioViewDTO>>(usuarios);

            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioViewDTO> GetUsuario(int id)
        {
            var usuario = _context.Usuarios.Include(u => u.Rol).Include(dt => dt.DatosGenerales).ThenInclude(dt => dt.Documento).FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = _mapper.Map<UsuarioViewDTO>(usuario);

            return Ok(usuarioDto);
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> CreateUsuario(UsuarioCreateDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            usuarioDto = _mapper.Map<UsuarioCreateDTO>(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(int id, UsuarioCreateDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
