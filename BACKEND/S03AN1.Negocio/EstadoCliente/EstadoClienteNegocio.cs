using S03AN1.Modelos.EstadoCliente;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.EstadoCliente;

namespace S03AN1.Negocio.EstadoCliente
{
    public class EstadoClienteNegocio : GenericNegocio<EstadoClienteRequest, EstadoClienteResponse, int>, IEstadoClienteNegocio
    {
        public EstadoClienteNegocio(IEstadoClienteRepositorio estadoClienteRepositorio) 
            : base(estadoClienteRepositorio)
        {
        }
    }
}