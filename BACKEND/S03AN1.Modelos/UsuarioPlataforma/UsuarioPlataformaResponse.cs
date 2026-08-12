using System;

namespace S03AN1.Modelos.UsuarioPlataforma
{
    public class UsuarioPlataformaResponse
    {
        public long Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string ClaveCifrada { get; set; } = string.Empty;
        public int IntentosFallidos { get; set; }
        public DateTime? BloqueadoHasta { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public ulong Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public string? UsuarioModificacion { get; set; }
    }
}
