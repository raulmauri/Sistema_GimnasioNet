using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class ClaseServiceRMB : IClaseServiceRMB
    {
        private readonly IClaseRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public ClaseServiceRMB(IClaseRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostClase(ClaseDtoRMB claseDto)
        {
            var entity = _mapper.Map<ClaseRMB>(claseDto);
            await _repo.PostClase(entity);
        }

        public async Task<List<ClaseDtoRMB>> GetClasesAll()
        {
            var list = await _repo.GetClasesAll();
            return list.Select(x => _mapper.Map<ClaseDtoRMB>(x)).ToList();
        }

        public async Task<ClaseDtoRMB?> GetClaseById(int idClase)
        {
            var ent = await _repo.GetClaseById(idClase);
            if (ent == null) return null;
            return _mapper.Map<ClaseDtoRMB>(ent);
        }

        public async Task UpdateClase(ClaseDtoRMB claseDto)
        {
            var entity = _mapper.Map<ClaseRMB>(claseDto);
            await _repo.UpdateClase(entity);
        }

        public async Task DeleteClase(int idClase)
        {
            var entity = await _repo.GetClaseById(idClase);
            if (entity == null) return;
            await _repo.DeleteClase(entity);
        }
    }
}