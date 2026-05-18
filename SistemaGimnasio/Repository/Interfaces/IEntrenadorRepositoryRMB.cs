using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IEntrenadorRepositoryRMB
    {
        Task PostEntrenador(EntrenadorRMB entrenador);
        Task<List<EntrenadorRMB>> GetEntrenadoresAll();
        Task<EntrenadorRMB?> GetEntrenadorById(int idEntrenador);
        Task UpdateEntrenador(EntrenadorRMB entrenador);
        Task DeleteEntrenador(EntrenadorRMB entrenador);
    }
}