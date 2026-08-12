using S03AN1.Modelos.Cliente;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.Cliente;

namespace S03AN1.Negocio.Cliente
{
    public class ClienteNegocio : GenericNegocio<ClienteRequest, ClienteResponse, int>, IClienteNegocio
    {
        public ClienteNegocio(IClienteRepositorio clienteRepositorio) 
            : base(clienteRepositorio)
        {
        }
    }
}
