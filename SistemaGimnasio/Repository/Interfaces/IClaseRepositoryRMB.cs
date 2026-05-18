using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IClaseRepositoryRMB
    {
        Task PostClase(ClaseRMB clase);
        Task<List<ClaseRMB>> GetClasesAll();
        Task<ClaseRMB?> GetClaseById(int idClase);
        Task UpdateClase(ClaseRMB clase);
        Task DeleteClase(ClaseRMB clase);
    }
}