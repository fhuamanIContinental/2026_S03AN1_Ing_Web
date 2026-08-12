using System;

namespace S03AN1.Modelos.ClienteSuscripcion
{
    public class ClienteSuscripcionResponse
    {
        public long Id { get; set; }
        public int IdCliente { get; set; }
        public int IdPlan { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public string Modalidad { get; set; } = string.Empty;
        public decimal MontoPactado { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public string? UsuarioModificacion { get; set; }
    }
}
