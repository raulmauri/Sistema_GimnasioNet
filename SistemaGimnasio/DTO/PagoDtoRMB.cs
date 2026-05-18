using System;

namespace SistemaGimnasio.DTO
{
    public class PagoDtoRMB
    {
        public int IdPago { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}