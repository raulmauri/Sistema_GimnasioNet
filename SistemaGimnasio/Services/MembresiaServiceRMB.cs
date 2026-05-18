using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class MembresiaServiceRMB : IMembresiaServiceRMB
    {
        private readonly IMembresiaRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public MembresiaServiceRMB(IMembresiaRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostMembresia(MembresiaDtoRMB membresiaDto)
        {
            var entity = _mapper.Map<MembresiaRMB>(membresiaDto);
            await _repo.PostMembresia(entity);
        }

        public async Task<List<MembresiaDtoRMB>> GetMembresiasAll()
        {
            var list = await _repo.GetMembresiasAll();
            return list.Select(x => _mapper.Map<MembresiaDtoRMB>(x)).ToList();
        }

        public async Task<MembresiaDtoRMB?> GetMembresiaById(int idMembresia)
        {
            var ent = await _repo.GetMembresiaById(idMembresia);
            if (ent == null) return null;
            return _mapper.Map<MembresiaDtoRMB>(ent);
        }

        public async Task UpdateMembresia(MembresiaDtoRMB membresiaDto)
        {
            var entity = _mapper.Map<MembresiaRMB>(membresiaDto);
            await _repo.UpdateMembresia(entity);
        }

        public async Task DeleteMembresia(int idMembresia)
        {
            var entity = await _repo.GetMembresiaById(idMembresia);
            if (entity == null) return;
            await _repo.DeleteMembresia(entity);
        }

        public async Task<List<PagoDtoRMB>> GetPagosByMembresia(int idMembresia)
        {
            var list = await _repo.GetPagosByMembresia(idMembresia);
            return list.Select(x => _mapper.Map<PagoDtoRMB>(x)).ToList();
        }
    }
}