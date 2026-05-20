using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrenadorController : ControllerBase
    {
        private readonly IEntrenadorServiceRMB _service;
        public EntrenadorController(IEntrenadorServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostEntrenador")]
        public async Task<IActionResult> Post([FromBody] EntrenadorDtoRMB dto)
        {
            await _service.PostEntrenador(dto);
            return Ok("El Entrenador fue registrado correctamente.");
        }

        [HttpGet("GetAllEntrenadores")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetEntrenadoresAll();
            return Ok(list);
        }

        [HttpGet("GetEntrenadorById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("El id no es valido.");

            var item = await _service.GetEntrenadorById(id);
            if (item == null) return NotFound("Entrenador no encontrado");
            return Ok(item);
        }

        [HttpPut("UpdateEntrenador")]
        public async Task<IActionResult> Update([FromBody] EntrenadorDtoRMB dto)
        {
            await _service.UpdateEntrenador(dto);
            return Ok("Los datos del Entrenador fueron actualizados correctamente.");
        }

        [HttpDelete("DeleteEntrenador/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("El id no es valido.");

            await _service.DeleteEntrenador(id);
            return Ok("Entrenador eliminado correctamente.");
        }
    }
}