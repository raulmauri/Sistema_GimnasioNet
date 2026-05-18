using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class EntrenadorRepositoryRMB : IEntrenadorRepositoryRMB
    {
        private readonly AppDbContext _db;
        public EntrenadorRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostEntrenador(EntrenadorRMB entrenador)
        {
            await _db.EntrenadoresRMB.AddAsync(entrenador);
            await _db.SaveChangesAsync();
        }

        public async Task<List<EntrenadorRMB>> GetEntrenadoresAll()
        {
            return await _db.EntrenadoresRMB.ToListAsync();
        }

        public async Task<EntrenadorRMB?> GetEntrenadorById(int idEntrenador)
        {
            return await _db.EntrenadoresRMB.FindAsync(idEntrenador);
        }

        public async Task UpdateEntrenador(EntrenadorRMB entrenador)
        {
            _db.EntrenadoresRMB.Update(entrenador);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEntrenador(EntrenadorRMB entrenador)
        {
            _db.EntrenadoresRMB.Remove(entrenador);
            await _db.SaveChangesAsync();
        }
    }
}