namespace S03AN1.Modelos.EstadoCliente
{
    public class EstadoClienteRequest
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

    }
}
