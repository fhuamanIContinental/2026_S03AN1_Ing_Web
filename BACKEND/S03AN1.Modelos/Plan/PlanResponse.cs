using System;

namespace S03AN1.Modelos.Plan
{
    public class PlanResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioMensual { get; set; }
        public decimal PrecioAnual { get; set; }
        public int? MaxEstudiante { get; set; }
        public int? MaxUsuario { get; set; }
        public ulong Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public string? UsuarioModificacion { get; set; }
        public string? CampoPrueba { get; set; }
    }
}
