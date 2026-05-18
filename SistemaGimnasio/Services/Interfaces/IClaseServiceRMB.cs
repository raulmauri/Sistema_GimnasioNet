using SistemaGimnasio.DTO;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IClaseServiceRMB
    {
        Task PostClase(ClaseDtoRMB claseDto);
        Task<List<ClaseDtoRMB>> GetClasesAll();
        Task<ClaseDtoRMB?> GetClaseById(int idClase);
        Task UpdateClase(ClaseDtoRMB claseDto);
        Task DeleteClase(int idClase);
    }
}