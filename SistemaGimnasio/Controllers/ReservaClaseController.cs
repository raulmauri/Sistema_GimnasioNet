using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaClaseController : ControllerBase
    {
        private readonly IReservaClaseServiceRMB _service;
        public ReservaClaseController(IReservaClaseServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostReservaClase")]
        public async Task<IActionResult> Post([FromBody] ReservaClaseDtoRMB dto)
        {
            await _service.PostReserva(dto);
            return Ok("Reserva de clase registrada correctamente.");
        }

        [HttpGet("GetReservasClasesAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetReservasAll();
            return Ok(list);
        }

        [HttpGet("GetReservaClaseById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetReservaById(id);
            if (item == null) return NotFound("Reserva de clase no encontrada.");
            return Ok(item);
        }

        [HttpPut("UpdateReservaClase")]
        public async Task<IActionResult> Update([FromBody] ReservaClaseDtoRMB dto)
        {
            await _service.UpdateReserva(dto);
            return Ok("Reserva de clase actualizada correctamente.");
        }

        [HttpDelete("DeleteReservaClase/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteReserva(id);
            return Ok("Reserva de clase eliminada correctamente.");
        }

        [HttpGet("GetReservasByCliente/{idCliente}")]
        public async Task<IActionResult> GetByCliente(int idCliente)
        {
            var list = await _service.GetReservasByCliente(idCliente);
            return Ok(list);
        }
    }
}