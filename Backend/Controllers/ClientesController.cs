using AutoMapper;
using SharedProject.DTOs;
using Backend.Interface;
using SharedProject.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewDTO>>> GetClientes()
        {
            var clientes =  await _clienteRepository.GetClientesWithData();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteViewDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewDTO>> GetCliente(int id)
        {
            var cliente =  _clienteRepository.GetClientesWithData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDTO = _mapper.Map<ClienteViewDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewDTO>> Create(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
             _clienteRepository.Add(cliente);
                
            var clienteDTO = _mapper.Map<ClienteViewDTO>(cliente);
            return CreatedAtAction(nameof(GetCliente), new { cliente.Id}, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteCreateDTO clienteUpdateDTO)
        {
            if (id != clienteUpdateDTO.Id)
            {
                return BadRequest();
            }

            var cliente =  _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(clienteUpdateDTO, cliente);
             _clienteRepository.Update(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente =  _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

             _clienteRepository.Delete(cliente);

            return NoContent();
        }
    }
}
