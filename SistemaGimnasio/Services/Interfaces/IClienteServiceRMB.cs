using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;

namespace SistemaGimnasio.Services.Interfaces
{
    public interface IClienteServiceRMB
    {
        Task PostCliente(ClienteDtoRMB clienteDto);
        Task<List<ClienteDtoRMB>> GetClientesAll();
        Task<ClienteDtoRMB?> GetClienteById(int idCliente);
        Task UpdateCliente(ClienteDtoRMB clienteDto);
        Task DeleteCliente(int idCliente);

        // relacional: devolver cliente y sus membresias en una sola respuesta
        Task<ClienteConMembresiasDtoRMB?> GetMembresiasByCliente(int idCliente);

        

    }
}