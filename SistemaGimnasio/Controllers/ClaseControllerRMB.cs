using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaseControllerRMB : ControllerBase
    {
        private readonly IClaseServiceRMB _service;
        public ClaseControllerRMB(IClaseServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostClase")]
        public async Task<IActionResult> Post([FromBody] ClaseDtoRMB dto)
        {
            await _service.PostClase(dto);
            return Ok("Clase creada correctamente");
        }

        [HttpGet("GetAllClases")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetClasesAll();
            return Ok(list);
        }

        [HttpGet("GetClaseById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetClaseById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("UpdateClase")]
        public async Task<IActionResult> Update([FromBody] ClaseDtoRMB dto)
        {
            await _service.UpdateClase(dto);
            return Ok("Clase actualizada correctamente");
        }

        [HttpDelete("DeleteClase/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteClase(id);
            return Ok("Clase Eliminada correctamente");
        }
    }
}