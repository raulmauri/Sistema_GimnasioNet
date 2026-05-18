using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class PagoServiceRMB : IPagoServiceRMB
    {
        private readonly IPagoRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public PagoServiceRMB(IPagoRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostPago(PagoDtoRMB pagoDto)
        {
            var entity = _mapper.Map<PagoRMB>(pagoDto);
            await _repo.PostPago(entity);
        }

        public async Task<List<PagoDtoRMB>> GetPagosAll()
        {
            var list = await _repo.GetPagosAll();
            return list.Select(x => _mapper.Map<PagoDtoRMB>(x)).ToList();
        }

        public async Task<PagoDtoRMB?> GetPagoById(int idPago)
        {
            var ent = await _repo.GetPagoById(idPago);
            if (ent == null) return null;
            return _mapper.Map<PagoDtoRMB>(ent);
        }

        public async Task UpdatePago(PagoDtoRMB pagoDto)
        {
            var entity = _mapper.Map<PagoRMB>(pagoDto);
            await _repo.UpdatePago(entity);
        }

        public async Task DeletePago(int idPago)
        {
            var entity = await _repo.GetPagoById(idPago);
            if (entity == null) return;
            await _repo.DeletePago(entity);
        }
    }
}