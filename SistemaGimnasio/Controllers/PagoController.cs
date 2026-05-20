using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoServiceRMB _service;
        public PagoController(IPagoServiceRMB service)
        {
            _service = service;
        }

        [HttpPost("PostPago")]
        public async Task<IActionResult> Post([FromBody] PagoDtoRMB dto)
        {
            await _service.PostPago(dto);
            return Ok("Pago registrado correctamente");
        }

        [HttpGet("GetAllPagos")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetPagosAll();
            return Ok(list);
        }

        [HttpGet("GetPagoById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetPagoById(id);
            if (item == null) return NotFound("Pago no encontrado.");
            return Ok(item);
        }

        [HttpPut("UpdatePago")]
        public async Task<IActionResult> Update([FromBody] PagoDtoRMB dto)
        {
            await _service.UpdatePago(dto);
            return Ok("Pago actaulizado correctamente");
        }

        [HttpDelete("DeletePago/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePago(id);
            return Ok();
        }
    }
}