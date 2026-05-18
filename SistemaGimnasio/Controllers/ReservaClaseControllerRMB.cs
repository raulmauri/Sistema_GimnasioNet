using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaClaseControllerRMB : ControllerBase
    {
        private readonly IReservaClaseServiceRMB _service;
        public ReservaClaseControllerRMB(IReservaClaseServiceRMB service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservaClaseDtoRMB dto)
        {
            await _service.PostReserva(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetReservasAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetReservaById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReservaClaseDtoRMB dto)
        {
            await _service.UpdateReserva(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteReserva(id);
            return Ok();
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> GetByCliente(int idCliente)
        {
            var list = await _service.GetReservasByCliente(idCliente);
            return Ok(list);
        }
    }
}