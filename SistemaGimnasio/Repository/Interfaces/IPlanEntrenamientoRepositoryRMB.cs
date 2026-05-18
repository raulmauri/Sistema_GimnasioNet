using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IPlanEntrenamientoRepositoryRMB
    {
        Task PostPlan(PlanEntrenamientoRMB plan);
        Task<List<PlanEntrenamientoRMB>> GetPlanesAll();
        Task<PlanEntrenamientoRMB?> GetPlanById(int idPlan);
        Task UpdatePlan(PlanEntrenamientoRMB plan);
        Task DeletePlan(PlanEntrenamientoRMB plan);
        Task<List<PlanEntrenamientoRMB>> GetPlanesByCliente(int idCliente);
    }
}