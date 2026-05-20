using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Model;

namespace SistemaGimnasio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db)
        {
            
        }
        
       
        // tablas gimnasio
        public DbSet<ClienteRMB> ClientesRMB { get; set; }
        public DbSet<EntrenadorRMB> EntrenadoresRMB { get; set; }
        public DbSet<MembresiaRMB> MembresiasRMB { get; set; }
        public DbSet<PagoRMB> PagosRMB { get; set; }
        public DbSet<ClaseRMB> ClasesRMB { get; set; }
        public DbSet<ReservaClaseRMB> ReservaClasesRMB { get; set; }
        public DbSet<PlanEntrenamientoRMB> PlanesEntrenamientoRMB { get; set; }
    

        protected override void OnModelCreating(ModelBuilder db)
        {


            // tablas gimnasio
            // declaramos las llaves primarias y foreaneas

            //Tabla cliente
            db.Entity<ClienteRMB>(X =>
            {
                X.HasKey(x => x.IdCliente);
            });
            //tabla emtrenador
            db.Entity<EntrenadorRMB>(X =>
            {
                X.HasKey(x => x.IdEntrenador);
            });
            //tabla mebresia
            db.Entity<MembresiaRMB>(X =>
            {
                X.HasKey(x => x.IdMembresia);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
            });
            //tabla pagos
            db.Entity<PagoRMB>(X =>
            {
                X.HasKey(x => x.IdPago);
                X.HasOne(p => p.Membresia).WithMany().HasForeignKey(p => p.IdMembresia).OnDelete(DeleteBehavior.Cascade);
            });
            //tabla clase
            db.Entity<ClaseRMB>(X =>
            {
                X.HasKey(x => x.IdClase);
                X.HasOne(p => p.Entrenador).WithMany().HasForeignKey(p => p.IdEntrenador).OnDelete(DeleteBehavior.Cascade);
            });
            //tabla reserva clase
            db.Entity<ReservaClaseRMB>(X =>
            {
                X.HasKey(x => x.IdReserva);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Clase).WithMany().HasForeignKey(p => p.IdClase).OnDelete(DeleteBehavior.Cascade);
            });
            //tabla plan entrenamiento
            db.Entity<PlanEntrenamientoRMB>(X =>
            {
                X.HasKey(x => x.IdPlan);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Entrenador).WithMany().HasForeignKey(p => p.IdEntrenador).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
