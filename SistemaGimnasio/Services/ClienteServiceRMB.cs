using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;
using SistemaGimnasio.Services.Interfaces;

namespace SistemaGimnasio.Services
{
    public class ClienteServiceRMB : IClienteServiceRMB
    {
        private readonly IClienteRepositoryRMB _repo;
        private readonly IMapper _mapper;
        public ClienteServiceRMB(IClienteRepositoryRMB repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task PostCliente(ClienteDtoRMB clienteDto)
        {
            var entity = _mapper.Map<ClienteRMB>(clienteDto);
            await _repo.PostCliente(entity);
        }

        public async Task<List<ClienteDtoRMB>> GetClientesAll()
        {
            var list = await _repo.GetClientesAll();
            return list.Select(x => _mapper.Map<ClienteDtoRMB>(x)).ToList();
        }

        public async Task<ClienteDtoRMB?> GetClienteById(int idCliente)
        {
            var entity = await _repo.GetClienteById(idCliente);
            if (entity == null) return null;
            return _mapper.Map<ClienteDtoRMB>(entity);
        }

        public async Task UpdateCliente(ClienteDtoRMB clienteDto)
        {
            var entity = _mapper.Map<ClienteRMB>(clienteDto);
            await _repo.UpdateCliente(entity);
        }

        public async Task DeleteCliente(int idCliente)
        {
            var entity = await _repo.GetClienteById(idCliente);
            if (entity == null) return;
            await _repo.DeleteCliente(entity);
        }

        public async Task<ClienteConMembresiasDtoRMB?> GetMembresiasByCliente(int idCliente)
        {
            var cliente = await _repo.GetClienteById(idCliente);
            if (cliente == null) return null;

            var membresias = await _repo.GetMembresiasByCliente(idCliente);
            //mapeo manual
            /*
            var dto = new ClienteConMembresiasDtoRMB
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Ci = cliente.Ci,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                FechaRegistro = cliente.FechaRegistro,
                Estado = cliente.Estado,
                Membresias = membresias.Select(m => _mapper.Map<MembresiaDtoRMB>(m)).ToList()
            };
            */
            //Auto mapper 
            var dto = _mapper.Map<ClienteConMembresiasDtoRMB>(cliente);
            dto.Membresias = _mapper.Map<List<MembresiaDtoRMB>>(membresias);
            
            
            //devolvemos el resultado
            return dto;
        }
    }
}