using System;

namespace SistemaGimnasio.Model
{
    public class PagoRMB
    {
        public int IdPago { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }

        public virtual MembresiaRMB Membresia { get; set; }
    }
}