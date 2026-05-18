using System;

namespace SistemaGimnasio.Model
{
    public class ClaseRMB
    {
        public int IdClase { get; set; }
        public int IdEntrenador { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Horario { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

        public virtual EntrenadorRMB Entrenador { get; set; }
    }
}