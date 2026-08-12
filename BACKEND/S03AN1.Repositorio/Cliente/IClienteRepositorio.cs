using S03AN1.Modelos.Cliente;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.Cliente
{
    public interface IClienteRepositorio : IGenericRepositorio<ClienteRequest, ClienteResponse, int>
    {
    }
}
