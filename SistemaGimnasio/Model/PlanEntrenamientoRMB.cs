using System;

namespace SistemaGimnasio.Model
{
    public class PlanEntrenamientoRMB
    {
        public int IdPlan { get; set; }
        public int IdCliente { get; set; }
        public int IdEntrenador { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }

        public virtual ClienteRMB Cliente { get; set; }
        public virtual EntrenadorRMB Entrenador { get; set; }
    }
}