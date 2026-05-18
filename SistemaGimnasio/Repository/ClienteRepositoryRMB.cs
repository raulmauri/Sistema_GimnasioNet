using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class ClienteRepositoryRMB : IClienteRepositoryRMB
    {
        private readonly AppDbContext _db;
        public ClienteRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostCliente(ClienteRMB cliente)
        {
            await _db.ClientesRMB.AddAsync(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ClienteRMB>> GetClientesAll()
        {
            return await _db.ClientesRMB.ToListAsync();
        }

        public async Task<ClienteRMB?> GetClienteById(int idCliente)
        {
            return await _db.ClientesRMB.FindAsync(idCliente);
        }

        public async Task UpdateCliente(ClienteRMB cliente)
        {
            _db.ClientesRMB.Update(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCliente(ClienteRMB cliente)
        {
            _db.ClientesRMB.Remove(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task<List<MembresiaRMB>> GetMembresiasByCliente(int idCliente)
        {
            return await _db.MembresiasRMB.Where(x => x.IdCliente == idCliente).ToListAsync();
        }
    }
}