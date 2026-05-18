using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IEntrenadorServiceRMB
    {
        Task PostEntrenador(EntrenadorDtoRMB entrenadorDto);
        Task<List<EntrenadorDtoRMB>> GetEntrenadoresAll();
        Task<EntrenadorDtoRMB?> GetEntrenadorById(int idEntrenador);
        Task UpdateEntrenador(EntrenadorDtoRMB entrenadorDto);
        Task DeleteEntrenador(int idEntrenador);
    }
}