using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IPagoRepositoryRMB
    {
        Task PostPago(PagoRMB pago);
        Task<List<PagoRMB>> GetPagosAll();
        Task<PagoRMB?> GetPagoById(int idPago);
        Task UpdatePago(PagoRMB pago);
        Task DeletePago(PagoRMB pago);
    }
}