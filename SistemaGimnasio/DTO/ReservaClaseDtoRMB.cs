using System;

namespace SistemaGimnasio.DTO
{
    public class ReservaClaseDtoRMB
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdClase { get; set; }
        public DateTime FechaReserva { get; set; }
        public bool Estado { get; set; }
    }
}