using System.Collections.Generic;

namespace SistemaGimnasio.DTO
{
    public class ClienteConMembresiasDtoRMB
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public List<MembresiaDtoRMB> Membresias { get; set; } = new List<MembresiaDtoRMB>();
    }
}
