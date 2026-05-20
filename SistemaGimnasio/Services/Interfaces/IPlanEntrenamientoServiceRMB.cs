using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IPlanEntrenamientoServiceRMB
    {
        Task PostPlan(PlanEntrenamientoDtoRMB planDto);
        Task<List<PlanEntrenamientoDtoRMB>> GetPlanesAll();
        Task<PlanEntrenamientoDtoRMB?> GetPlanById(int idPlan);
        Task UpdatePlan(PlanEntrenamientoDtoRMB planDto);
        Task DeletePlan(int idPlan);
        Task<List<PlanEntrenamientoClienteEntranadorDtoRMB>> GetPlanesByCliente(int idCliente);
    }
}