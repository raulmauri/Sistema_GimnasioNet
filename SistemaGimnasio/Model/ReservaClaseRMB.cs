using System;

namespace SistemaGimnasio.Model
{
    public class ReservaClaseRMB
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaReserva { get; set; }
        public bool Estado { get; set; }

        public virtual ClienteRMB Cliente { get; set; }
        public virtual ClaseRMB Clase { get; set; }
    }
}