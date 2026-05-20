using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class PlanEntrenamientoServiceRMB : IPlanEntrenamientoServiceRMB
    {
        private readonly IPlanEntrenamientoRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public PlanEntrenamientoServiceRMB(IPlanEntrenamientoRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostPlan(PlanEntrenamientoDtoRMB planDto)
        {
            var entity = _mapper.Map<PlanEntrenamientoRMB>(planDto);
            await _repo.PostPlan(entity);
        }

        public async Task<List<PlanEntrenamientoDtoRMB>> GetPlanesAll()
        {
            var list = await _repo.GetPlanesAll();
            return list.Select(x => _mapper.Map<PlanEntrenamientoDtoRMB>(x)).ToList();
        }

        public async Task<PlanEntrenamientoDtoRMB?> GetPlanById(int idPlan)
        {
            var ent = await _repo.GetPlanById(idPlan);
            if (ent == null) return null;
            return _mapper.Map<PlanEntrenamientoDtoRMB>(ent);
        }

        public async Task UpdatePlan(PlanEntrenamientoDtoRMB planDto)
        {
            var entity = _mapper.Map<PlanEntrenamientoRMB>(planDto);
            await _repo.UpdatePlan(entity);
        }

        public async Task DeletePlan(int idPlan)
        {
            var entity = await _repo.GetPlanById(idPlan);
            if (entity == null) return;
            await _repo.DeletePlan(entity);
        }

        public async Task<List<PlanEntrenamientoClienteEntranadorDtoRMB>> GetPlanesByCliente(int idCliente)
        {
            var list = await _repo.GetPlanesByCliente(idCliente);
            // CAMBIO: el mapeo ahora incluirá ClienteNombre y EntrenadorNombre gracias a AutoMapper
            return list.Select(x => _mapper.Map<PlanEntrenamientoClienteEntranadorDtoRMB>(x)).ToList();
        }
    }
}