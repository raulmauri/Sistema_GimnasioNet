using SistemaGimnasio.Model;

namespace SistemaGimnasio.Repository.Interfaces
{
    public interface IClienteRepositoryRMB
    {
        Task PostCliente(ClienteRMB cliente);
        Task<List<ClienteRMB>> GetClientesAll();
        Task<ClienteRMB?> GetClienteById(int idCliente);
        Task UpdateCliente(ClienteRMB cliente);
        Task DeleteCliente(ClienteRMB cliente);

        // relaciones
        Task<List<MembresiaRMB>> GetMembresiasByCliente(int idCliente);


    }
}