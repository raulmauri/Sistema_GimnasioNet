using Microsoft.EntityFrameworkCore;
using SistemaGimnasio.Model;

namespace SistemaGimnasio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db)
        {
            
        }
        //tablas 
        // DbSet de almacén eliminados intencionalmente para migraciones centradas en gimnasio
        
        // tablas gimnasio
        public DbSet<ClienteRMB> ClientesRMB { get; set; }
        public DbSet<EntrenadorRMB> EntrenadoresRMB { get; set; }
        public DbSet<MembresiaRMB> MembresiasRMB { get; set; }
        public DbSet<PagoRMB> PagosRMB { get; set; }
        public DbSet<ClaseRMB> ClasesRMB { get; set; }
        public DbSet<ReservaClaseRMB> ReservaClasesRMB { get; set; }
        public DbSet<PlanEntrenamientoRMB> PlanesEntrenamientoRMB { get; set; }

        //declarar mis llaves foraneas y primarias

        protected override void OnModelCreating(ModelBuilder db)
        {
            // Ignorar entidades del almacén para no incluirlas en las migraciones
            //db.Ignore<Usuario>();
            //db.Ignore<Credenciales>();
            //db.Ignore<Camion>();
            //db.Ignore<RolesDetalle>();
            //db.Ignore<Roles>();
            //db.Ignore<Categoria>();
            //db.Ignore<Producto>();
            //db.Ignore<Pedido>();
            //db.Ignore<DetallePedido>();
            //db.Ignore<Despacho>();
            //db.Ignore<DetalleDespacho>();

            // tablas gimnasio
            db.Entity<ClienteRMB>(X =>
            {
                X.HasKey(x => x.IdCliente);
            });

            db.Entity<EntrenadorRMB>(X =>
            {
                X.HasKey(x => x.IdEntrenador);
            });

            db.Entity<MembresiaRMB>(X =>
            {
                X.HasKey(x => x.IdMembresia);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
            });

            db.Entity<PagoRMB>(X =>
            {
                X.HasKey(x => x.IdPago);
                X.HasOne(p => p.Membresia).WithMany().HasForeignKey(p => p.IdMembresia).OnDelete(DeleteBehavior.Cascade);
            });

            db.Entity<ClaseRMB>(X =>
            {
                X.HasKey(x => x.IdClase);
                X.HasOne(p => p.Entrenador).WithMany().HasForeignKey(p => p.IdEntrenador).OnDelete(DeleteBehavior.Cascade);
            });

            db.Entity<ReservaClaseRMB>(X =>
            {
                X.HasKey(x => x.IdReserva);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Clase).WithMany().HasForeignKey(p => p.IdClase).OnDelete(DeleteBehavior.Cascade);
            });

            db.Entity<PlanEntrenamientoRMB>(X =>
            {
                X.HasKey(x => x.IdPlan);
                X.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Cascade);
                X.HasOne(p => p.Entrenador).WithMany().HasForeignKey(p => p.IdEntrenador).OnDelete(DeleteBehavior.Cascade);
            });










        }









    }
}
