using System;

namespace SistemaGimnasio.DTO
{
    public class PlanEntrenamientoDtoRMB
    {
        public int IdPlan { get; set; }
        public int IdCliente { get; set; }
        public int IdEntrenador { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
    }
}