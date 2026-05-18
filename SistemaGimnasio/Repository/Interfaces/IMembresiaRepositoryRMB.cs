using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IMembresiaRepositoryRMB
    {
        Task PostMembresia(MembresiaRMB membresia);
        Task<List<MembresiaRMB>> GetMembresiasAll();
        Task<MembresiaRMB?> GetMembresiaById(int idMembresia);
        Task UpdateMembresia(MembresiaRMB membresia);
        Task DeleteMembresia(MembresiaRMB membresia);
        Task<List<PagoRMB>> GetPagosByMembresia(int idMembresia);
    }
}