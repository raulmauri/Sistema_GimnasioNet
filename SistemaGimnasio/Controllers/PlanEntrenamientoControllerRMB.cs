using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanEntrenamientoControllerRMB : ControllerBase
    {
        private readonly IPlanEntrenamientoServiceRMB _service;
        public PlanEntrenamientoControllerRMB(IPlanEntrenamientoServiceRMB service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlanEntrenamientoDtoRMB dto)
        {
            await _service.PostPlan(dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetPlanesAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetPlanById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PlanEntrenamientoDtoRMB dto)
        {
            await _service.UpdatePlan(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePlan(id);
            return Ok();
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> GetByCliente(int idCliente)
        {
            var list = await _service.GetPlanesByCliente(idCliente);
            return Ok(list);
        }
    }
}