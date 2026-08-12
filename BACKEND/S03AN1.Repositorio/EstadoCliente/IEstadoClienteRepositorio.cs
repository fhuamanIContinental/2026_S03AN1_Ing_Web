using S03AN1.Modelos.EstadoCliente;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.EstadoCliente
{
    public interface IEstadoClienteRepositorio : IGenericRepositorio<EstadoClienteRequest, EstadoClienteResponse, int>
    {
    }
}
