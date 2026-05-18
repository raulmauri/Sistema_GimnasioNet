using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IReservaClaseRepositoryRMB
    {
        Task PostReserva(ReservaClaseRMB reserva);
        Task<List<ReservaClaseRMB>> GetReservasAll();
        Task<ReservaClaseRMB?> GetReservaById(int idReserva);
        Task UpdateReserva(ReservaClaseRMB reserva);
        Task DeleteReserva(ReservaClaseRMB reserva);
        Task<List<ReservaClaseRMB>> GetReservasByCliente(int idCliente);
    }
}