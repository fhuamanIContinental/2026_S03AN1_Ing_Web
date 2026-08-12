using S03AN1.Modelos.Cliente;
using S03AN1.Negocio.General;

namespace S03AN1.Negocio.Cliente
{
    public interface IClienteNegocio : IGenericNegocio<ClienteRequest, ClienteResponse, int>
    {
    }
}
