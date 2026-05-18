using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembresiaControllerRMB : ControllerBase
    {
        private readonly IMembresiaServiceRMB _service;
        public MembresiaControllerRMB(IMembresiaServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostMembresia")]
        public async Task<IActionResult> Post([FromBody] MembresiaDtoRMB dto)
        {
            await _service.PostMembresia(dto);
            return Ok("Membresia registrada correctamtente.");
        }

        [HttpGet("GetAllMembresias")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetMembresiasAll();
            return Ok(list);
        }

        [HttpGet("GetMembresiaById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetMembresiaById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("UpdateMembresia")]
        public async Task<IActionResult> Update([FromBody] MembresiaDtoRMB dto)
        {
            await _service.UpdateMembresia(dto);
            return Ok("Datos de la membresia actualizados correctamente.");
        }

        [HttpDelete("DeleteMembresia/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMembresia(id);
            return Ok("Membresia eliminada correctamente.");
        }

        //***********************************************************

        // CAMBIO: Endpoint mejorado que retorna información completa de la membresía
        // incluyendo datos del cliente propietario y sus pagos realizados
        [HttpGet("GetMembresia/{id}/pagos")]
        public async Task<IActionResult> GetPagos(int id)
        {
            var result = await _service.GetMembresiaConClienteYPagos(id);
            if (result == null) return NotFound("La membresía no fue encontrada.");
            return Ok(result);
        }
    }
}