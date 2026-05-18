using System;

namespace SistemaGimnasio.DTO
{
    public class ClaseDtoRMB
    {
        public int IdClase { get; set; }
        public int IdEntrenador { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Horario { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
    }
}