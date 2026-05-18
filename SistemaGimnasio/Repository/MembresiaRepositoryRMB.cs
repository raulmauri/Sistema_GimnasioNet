using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class MembresiaRepositoryRMB : IMembresiaRepositoryRMB
    {
        private readonly AppDbContext _db;
        public MembresiaRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostMembresia(MembresiaRMB membresia)
        {
            await _db.MembresiasRMB.AddAsync(membresia);
            await _db.SaveChangesAsync();
        }

        public async Task<List<MembresiaRMB>> GetMembresiasAll()
        {
            return await _db.MembresiasRMB.ToListAsync();
        }

        public async Task<MembresiaRMB?> GetMembresiaById(int idMembresia)
        {
            return await _db.MembresiasRMB.FindAsync(idMembresia);
        }

        public async Task UpdateMembresia(MembresiaRMB membresia)
        {
            _db.MembresiasRMB.Update(membresia);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMembresia(MembresiaRMB membresia)
        {
            _db.MembresiasRMB.Remove(membresia);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PagoRMB>> GetPagosByMembresia(int idMembresia)
        {
            return await _db.PagosRMB.Where(x => x.IdMembresia == idMembresia).ToListAsync();
        }
    }
}