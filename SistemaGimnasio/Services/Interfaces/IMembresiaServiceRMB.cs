using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IMembresiaServiceRMB
    {
        Task PostMembresia(MembresiaDtoRMB membresiaDto);
        Task<List<MembresiaDtoRMB>> GetMembresiasAll();
        Task<MembresiaDtoRMB?> GetMembresiaById(int idMembresia);
        Task UpdateMembresia(MembresiaDtoRMB membresiaDto);
        Task DeleteMembresia(int idMembresia);

        Task<List<PagoDtoRMB>> GetPagosByMembresia(int idMembresia);
    }
}