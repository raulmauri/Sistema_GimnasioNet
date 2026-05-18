using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IPagoServiceRMB
    {
        Task PostPago(PagoDtoRMB pagoDto);
        Task<List<PagoDtoRMB>> GetPagosAll();
        Task<PagoDtoRMB?> GetPagoById(int idPago);
        Task UpdatePago(PagoDtoRMB pagoDto);
        Task DeletePago(int idPago);
    }
}