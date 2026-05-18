using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteControllerRMB : ControllerBase
    {
        private readonly IClienteServiceRMB _service;
        public ClienteControllerRMB(IClienteServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostCliente")]
        public async Task<IActionResult> Post([FromBody] ClienteDtoRMB dto)
        {
            await _service.PostCliente(dto);
            return Ok("Usuario creado correctamente");
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
            var item = await _service.GetClienteById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Update([FromBody] ClienteDtoRMB dto)
        {
            await _service.UpdateCliente(dto);
            return Ok("Usuario actualizado correctamente");
        }

        [HttpDelete("DeleteCliente/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCliente(id);
            return Ok("Usuario eliminado correctamente");
        }

        [HttpGet("GetCliente/{id}/membresias")]
        public async Task<IActionResult> GetMembresias(int id)
        {
            var list = await _service.GetMembresiasByCliente(id);
            return Ok(list);
        }
    }
}