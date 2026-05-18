using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class ReservaClaseServiceRMB : IReservaClaseServiceRMB
    {
        private readonly IReservaClaseRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public ReservaClaseServiceRMB(IReservaClaseRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostReserva(ReservaClaseDtoRMB reservaDto)
        {
            var entity = _mapper.Map<ReservaClaseRMB>(reservaDto);
            await _repo.PostReserva(entity);
        }

        public async Task<List<ReservaClaseDtoRMB>> GetReservasAll()
        {
            var list = await _repo.GetReservasAll();
            return list.Select(x => _mapper.Map<ReservaClaseDtoRMB>(x)).ToList();
        }

        public async Task<ReservaClaseDtoRMB?> GetReservaById(int idReserva)
        {
            var ent = await _repo.GetReservaById(idReserva);
            if (ent == null) return null;
            return _mapper.Map<ReservaClaseDtoRMB>(ent);
        }

        public async Task UpdateReserva(ReservaClaseDtoRMB reservaDto)
        {
            var entity = _mapper.Map<ReservaClaseRMB>(reservaDto);
            await _repo.UpdateReserva(entity);
        }

        public async Task DeleteReserva(int idReserva)
        {
            var entity = await _repo.GetReservaById(idReserva);
            if (entity == null) return;
            await _repo.DeleteReserva(entity);
        }

        public async Task<List<ReservaClaseDtoRMB>> GetReservasByCliente(int idCliente)
        {
            var list = await _repo.GetReservasByCliente(idCliente);
            return list.Select(x => _mapper.Map<ReservaClaseDtoRMB>(x)).ToList();
        }
    }
}