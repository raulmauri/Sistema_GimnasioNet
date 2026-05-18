using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IReservaClaseServiceRMB
    {
        Task PostReserva(ReservaClaseDtoRMB reservaDto);
        Task<List<ReservaClaseDtoRMB>> GetReservasAll();
        Task<ReservaClaseDtoRMB?> GetReservaById(int idReserva);
        Task UpdateReserva(ReservaClaseDtoRMB reservaDto);
        Task DeleteReserva(int idReserva);
        Task<List<ReservaClaseDtoRMB>> GetReservasByCliente(int idCliente);
    }
}