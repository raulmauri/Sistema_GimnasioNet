using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class PlanEntrenamientoRepositoryRMB : IPlanEntrenamientoRepositoryRMB
    {
        private readonly AppDbContext _db;
        public PlanEntrenamientoRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostPlan(PlanEntrenamientoRMB plan)
        {
            await _db.PlanesEntrenamientoRMB.AddAsync(plan);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PlanEntrenamientoRMB>> GetPlanesAll()
        {
            return await _db.PlanesEntrenamientoRMB.ToListAsync();
        }

        public async Task<PlanEntrenamientoRMB?> GetPlanById(int idPlan)
        {
            return await _db.PlanesEntrenamientoRMB.FindAsync(idPlan);
        }

        public async Task UpdatePlan(PlanEntrenamientoRMB plan)
        {
            _db.PlanesEntrenamientoRMB.Update(plan);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePlan(PlanEntrenamientoRMB plan)
        {
            _db.PlanesEntrenamientoRMB.Remove(plan);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PlanEntrenamientoRMB>> GetPlanesByCliente(int idCliente)
        {
            return await _db.PlanesEntrenamientoRMB.Where(x => x.IdCliente == idCliente).ToListAsync();
        }
    }
}