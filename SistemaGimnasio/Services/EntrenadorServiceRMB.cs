using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class EntrenadorServiceRMB : IEntrenadorServiceRMB
    {
        private readonly IEntrenadorRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public EntrenadorServiceRMB(IEntrenadorRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostEntrenador(EntrenadorDtoRMB entrenadorDto)
        {
            var entity = _mapper.Map<EntrenadorRMB>(entrenadorDto);
            await _repo.PostEntrenador(entity);
        }

        public async Task<List<EntrenadorDtoRMB>> GetEntrenadoresAll()
        {
            var list = await _repo.GetEntrenadoresAll();
            return list.Select(x => _mapper.Map<EntrenadorDtoRMB>(x)).ToList();
        }

        public async Task<EntrenadorDtoRMB?> GetEntrenadorById(int idEntrenador)
        {
            var ent = await _repo.GetEntrenadorById(idEntrenador);
            if (ent == null) return null;
            return _mapper.Map<EntrenadorDtoRMB>(ent);
        }

        public async Task UpdateEntrenador(EntrenadorDtoRMB entrenadorDto)
        {
            var entity = _mapper.Map<EntrenadorRMB>(entrenadorDto);
            await _repo.UpdateEntrenador(entity);
        }

        public async Task DeleteEntrenador(int idEntrenador)
        {
            var entity = await _repo.GetEntrenadorById(idEntrenador);
            if (entity == null) return;
            await _repo.DeleteEntrenador(entity);
        }
    }
}