using S03AN1.Modelos.EstadoCliente;
using S03AN1.Negocio.General;

namespace S03AN1.Negocio.EstadoCliente
{
    public interface IEstadoClienteNegocio : IGenericNegocio<EstadoClienteRequest, EstadoClienteResponse, int>
    {
    }
}
