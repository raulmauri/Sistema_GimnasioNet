using System;

namespace SistemaGimnasio.DTO
{
    public class CrearMembresiaDtoRMB
    {
        public int IdMembresia { get; set; }
        public int IdCliente { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
