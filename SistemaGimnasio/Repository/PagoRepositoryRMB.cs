using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class PagoRepositoryRMB : IPagoRepositoryRMB
    {
        private readonly AppDbContext _db;
        public PagoRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostPago(PagoRMB pago)
        {
            await _db.PagosRMB.AddAsync(pago);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PagoRMB>> GetPagosAll()
        {
            return await _db.PagosRMB.ToListAsync();
        }

        public async Task<PagoRMB?> GetPagoById(int idPago)
        {
            return await _db.PagosRMB.FindAsync(idPago);
        }

        public async Task UpdatePago(PagoRMB pago)
        {
            _db.PagosRMB.Update(pago);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePago(PagoRMB pago)
        {
            _db.PagosRMB.Remove(pago);
            await _db.SaveChangesAsync();
        }
    }
}