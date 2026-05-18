using System;

namespace SistemaGimnasio.DTO
{
    /// <summary>
    /// DTO mejorado que contiene información completa de una membresía
    /// incluyendo datos del cliente propietario y sus pagos realizados.
    /// CAMBIO: Nuevo DTO creado para mejorar el endpoint GetMembresia/{id}/pagos
    /// </summary>
    public class MembresiaConClienteYPagosDtoRMB
    {
        // Datos de la membresía
        public int IdMembresia { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        // CAMBIO: Información del cliente propietario de la membresía
        public ClienteInfoDtoRMB Cliente { get; set; }

        // CAMBIO: Lista de pagos realizados para esta membresía
        public List<PagoDtoRMB> Pagos { get; set; } = new List<PagoDtoRMB>();

        // CAMBIO: Información adicional de control
        public decimal MontoTotalPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
    }

    /// <summary>
    /// DTO con información resumida del cliente (para evitar datos sensibles innecesarios)
    /// CAMBIO: DTO anidado creado para mantener información del cliente dentro de MembresiaConClienteYPagosDtoRMB
    /// </summary>
    public class ClienteInfoDtoRMB
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
