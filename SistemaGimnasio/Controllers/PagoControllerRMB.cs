using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoControllerRMB : ControllerBase
    {
        private readonly IPagoServiceRMB _service;
        public PagoControllerRMB(IPagoServiceRMB service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PagoDtoRMB dto)
        {
            await _service.PostPago(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetPagosAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetPagoById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PagoDtoRMB dto)
        {
            await _service.UpdatePago(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePago(id);
            return Ok();
        }
    }
}