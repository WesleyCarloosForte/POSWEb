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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ProveedorController(IProveedorRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorViewDTO>>> GetClientes()
        {
            var clientes =  await _clienteRepository.GetClientesWithData();
            var clientesDTO = _mapper.Map<IEnumerable<ProveedorViewDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorViewDTO>> GetCliente(int id)
        {
            var cliente =  _clienteRepository.GetClientesWithData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDTO = _mapper.Map<ProveedorViewDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorViewDTO>> Create(ProveedorCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Proveedor>(clienteCreateDTO);
             _clienteRepository.Add(cliente);
                
            var clienteDTO = _mapper.Map<ProveedorCreateDTO>(cliente);
            return CreatedAtAction(nameof(GetCliente), new { cliente.Id}, clienteDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProveedorCreateDTO clienteUpdateDTO)
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
