using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class ReservaClaseRepositoryRMB : IReservaClaseRepositoryRMB
    {
        private readonly AppDbContext _db;
        public ReservaClaseRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostReserva(ReservaClaseRMB reserva)
        {
            await _db.ReservaClasesRMB.AddAsync(reserva);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReservaClaseRMB>> GetReservasAll()
        {
            return await _db.ReservaClasesRMB.ToListAsync();
        }

        public async Task<ReservaClaseRMB?> GetReservaById(int idReserva)
        {
            return await _db.ReservaClasesRMB.FindAsync(idReserva);
        }

        public async Task UpdateReserva(ReservaClaseRMB reserva)
        {
            _db.ReservaClasesRMB.Update(reserva);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteReserva(ReservaClaseRMB reserva)
        {
            _db.ReservaClasesRMB.Remove(reserva);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ReservaClaseRMB>> GetReservasByCliente(int idCliente)
        {
            return await _db.ReservaClasesRMB.Where(x => x.IdCliente == idCliente).ToListAsync();
        }
    }
}