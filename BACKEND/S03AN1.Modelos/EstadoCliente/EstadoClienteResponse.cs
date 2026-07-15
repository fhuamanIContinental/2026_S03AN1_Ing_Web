using System;
using System.Collections.Generic;
using System.Text;

namespace S03AN1.Modelos.EstadoCliente
{
    public class EstadoClienteResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
