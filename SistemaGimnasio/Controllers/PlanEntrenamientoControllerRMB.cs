using Microsoft.AspNetCore.Mvc;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Services.Interfaces;
using System.Numerics;

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

        [HttpPost("PostPlanEntrenamiento")]
        public async Task<IActionResult> Post([FromBody] PlanEntrenamientoDtoRMB dto)
        {
            await _service.PostPlan(dto);
            return Ok("Plan de entrenamiento registrado correctamente");
        }

        [HttpGet("GetAllPlanEntrenamiento")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetPlanesAll();
            return Ok(list);
        }

        [HttpGet("GetPlanEntrenamientoById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetPlanById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("UpdatePlanEntrenamiento")]
        public async Task<IActionResult> Update([FromBody] PlanEntrenamientoDtoRMB dto)
        {
            await _service.UpdatePlan(dto);
            return Ok("Plan de entrenamiento actualizado correctamente");
        }

        [HttpDelete("DeletePlanEntrenamiento/   {id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePlan(id);
            return Ok("Plan de entrenamiento eliminado correctamente");
        }

        [HttpGet("GetPlanesByCliente/{idCliente}")]
        public async Task<IActionResult> GetByCliente(int idCliente)
        {
            var list = await _service.GetPlanesByCliente(idCliente);
            return Ok(list);
        }
    }
}