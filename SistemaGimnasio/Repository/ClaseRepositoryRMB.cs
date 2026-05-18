using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Data;
using SistemaGimnasio.Model;
using SistemaGimnasio.Repository.Interfaces;

namespace SistemaGimnasio.Repository
{
    public class ClaseRepositoryRMB : IClaseRepositoryRMB
    {
        private readonly AppDbContext _db;
        public ClaseRepositoryRMB(AppDbContext db)
        {
            _db = db;
        }

        public async Task PostClase(ClaseRMB clase)
        {
            await _db.ClasesRMB.AddAsync(clase);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ClaseRMB>> GetClasesAll()
        {
            return await _db.ClasesRMB.ToListAsync();
        }

        public async Task<ClaseRMB?> GetClaseById(int idClase)
        {
            return await _db.ClasesRMB.FindAsync(idClase);
        }

        public async Task UpdateClase(ClaseRMB clase)
        {
            _db.ClasesRMB.Update(clase);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteClase(ClaseRMB clase)
        {
            _db.ClasesRMB.Remove(clase);
            await _db.SaveChangesAsync();
        }
    }
}