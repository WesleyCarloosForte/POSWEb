using AutoMapper;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _Context;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper,DataContext context)

        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewDTO>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteRepository.GetClientesWithData();
                var clientesDTO = _mapper.Map<IEnumerable<ClienteViewDTO>>(clientes);
                return Ok(clientesDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("filter/{txt}")]
        public async Task<ActionResult<IEnumerable<ClienteViewDTO>>> GetClientes(string txt)
        {
            try
            {
                var clientes = await _clienteRepository.GetClientesWithData(x => x.DatosGenerales.NumeroDocumento.Contains(txt) || x.DatosGenerales.Nombre.ToLower().Contains(txt.ToLower()));
                var clientesDTO = _mapper.Map<IEnumerable<ClienteViewDTO>>(clientes);
                return Ok(clientesDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpGet("DOcumento/{dc}")]
        public async Task<ActionResult<ClienteViewDTO>> GetCliente(string dc)
        {
            try
            {
                var result= await _clienteRepository.GetClientesWithData(x => x.DatosGenerales.NumeroDocumento == dc);
                var cliente = result.FirstOrDefault();
                if (cliente == null)
                {
                    var res = await _clienteRepository.GetClientesWithData(x => x.DatosGenerales.Nombre == "Default");
                    cliente = res.FirstOrDefault();
                    if (cliente == null )
                    return NotFound();
                }
                var clienteDTO = _mapper.Map<ClienteViewDTO>(cliente);
                return Ok(clienteDTO);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewDTO>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClientesWithData(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                var clienteDTO = _mapper.Map<ClienteViewDTO>(cliente);
                return Ok(clienteDTO);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
  

        [HttpGet("edit/{id}")]
        public async Task<ActionResult<ClienteCreateDTO>> GetEditCliente(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetClientesWithData(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                var clienteDTO = _mapper.Map<ClienteCreateDTO>(cliente);
                return Ok(clienteDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewDTO>> Create(ClienteCreateDTO clienteCreateDTO)
        {
            try
            {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            cliente.DatosGenerales.Estado = true;
            _clienteRepository.Add(cliente);

            var clienteDTO = _mapper.Map<ClienteViewDTO>(cliente);
            return CreatedAtAction(nameof(GetCliente), new { cliente.Id }, clienteDTO);
        }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteCreateDTO clienteUpdateDTO)
        {
            try
            {
                if (id != clienteUpdateDTO.Id)
                {
                    return BadRequest();
                }

                var cliente = _clienteRepository.GetById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                var clm = new Cliente();

                _mapper.Map(clienteUpdateDTO, clm);

                cliente.DatosGenerales = clm.DatosGenerales;

                _clienteRepository.Update(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var cliente = _clienteRepository.GetById(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                _clienteRepository.Delete(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
