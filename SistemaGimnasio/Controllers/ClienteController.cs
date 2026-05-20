using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServiceRMB _service;
        public ClienteController(IClienteServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostCliente")]
        public async Task<IActionResult> Post([FromBody] ClienteDtoRMB dto)
        {
            await _service.PostCliente(dto);
            return Ok("Cliente creado correctamente.");
        }

        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetClientesAll();
            return Ok(list);
        }

        [HttpGet("GetClienteById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("El id no valido");

            var item = await _service.GetClienteById(id);
            if (item == null) return NotFound("Cliente no encontrado.");
            return Ok(item);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Update([FromBody] ClienteDtoRMB dto)
        {
            await _service.UpdateCliente(dto);
            return Ok("Cliente actualizado correctamente.");
        }

        [HttpDelete("DeleteCliente/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("El id no es valido.");

            await _service.DeleteCliente(id);
            return Ok("Cliente eliminado correctamente.");
        }

        [HttpGet("GetCliente/{id}/membresias")]
        public async Task<IActionResult> GetMembresias(int id)
        {
            if (id <= 0) return BadRequest("El id no es valido.");

            var list = await _service.GetMembresiasByCliente(id);
            return Ok(list);
        }
    }
}