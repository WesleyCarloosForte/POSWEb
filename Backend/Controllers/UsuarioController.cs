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
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioController(DataContext context, IMapper mapper)
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

        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewDTO>>> GetAll(string txt)
        {
            try
            {
                var usuario = _context.Usuarios.Include(u => u.Rol).Include(dt => dt.DatosGenerales).ThenInclude(dt => dt.Documento)
                    .Where(u=>u.DatosGenerales.Nombre.Contains(txt) 
                    || u.Login.Contains(txt) 
                    || u.DatosGenerales.NumeroDocumento.Contains(txt) 
                    || u.Rol.Descripcion.Contains(txt)).ToArray();

                if (usuario == null)
                {
                    return NotFound();
                }

                var usuarioDto = _mapper.Map<IEnumerable<UsuarioViewDTO>>(usuario);

                return Ok(usuarioDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("edit/{id}")]
        public ActionResult<UsuarioCreateDTO> GetEditUsuario(int id)
        {
            var usuario = _context.Usuarios.Include(u => u.Rol).Include(dt => dt.DatosGenerales).ThenInclude(dt => dt.Documento).FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = _mapper.Map<UsuarioCreateDTO>(usuario);

            return Ok(usuarioDto);
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> CreateUsuario(UsuarioCreateDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.DatosGenerales.Estado = true;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            usuarioDto = _mapper.Map<UsuarioCreateDTO>(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task< IActionResult> UpdateUsuario(int id, UsuarioCreateDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest();
            }

           // var datosGeneralId = await _context.DatosGenerales.FirstOrDefaultAsync(x => x.NumeroDocumento == usuarioDto.NumeroDocumento);

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = usuarioDto.Id;
            usuario.RolId= usuarioDto.RolId;
            usuario.DatosGenerales.DocumentoId = usuarioDto.DocumentoId;
            // usuario.DatosGenerales.Id= datosGeneralId.Id;
            //usuario.DatosGeneralesId = datosGeneralId.Id;

            var usr = _context.Usuarios.Find(id);

            usuario.DatosGeneralesId= usr.Id;

            if(usr != null)
            {
                
                usr.RolId = usuario.RolId;
                usr.Login= usuario.Login;
                usr.Password= usuario.Password;
                
                var entityGeneral = _context.DatosGenerales.Find(usr.DatosGeneralesId);
                
                    entityGeneral.Nombre = usuario.DatosGenerales.Nombre;
                    entityGeneral.Telefono = usuario.DatosGenerales.Telefono;
                    entityGeneral.Estado = usuario.DatosGenerales.Estado;
                    entityGeneral.NumeroDocumento = usuario.DatosGenerales.NumeroDocumento;
                    entityGeneral.Direccion = usuario.DatosGenerales.Direccion;
                    entityGeneral.Email = usuario.DatosGenerales.Email;
                    entityGeneral.DocumentoId = usuario.DatosGenerales.DocumentoId;

                _context.Entry(entityGeneral).State = EntityState.Modified;
                _context.Entry(usr).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();


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
