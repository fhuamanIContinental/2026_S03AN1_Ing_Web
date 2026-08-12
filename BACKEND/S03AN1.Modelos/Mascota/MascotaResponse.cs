using System;

namespace S03AN1.Modelos.Mascota
{
    public class MascotaResponse
    {
        public int Id { get; set; }
        public string? CategoriaMascota { get; set; }
        public string? Raza { get; set; }
        public int? Edad { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public string? UsuarioModificacion { get; set; }
    }
}
