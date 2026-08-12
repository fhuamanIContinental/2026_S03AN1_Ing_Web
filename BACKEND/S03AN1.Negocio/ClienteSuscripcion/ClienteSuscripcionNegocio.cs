using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.ClienteSuscripcion;

namespace S03AN1.Negocio.ClienteSuscripcion
{
    public class ClienteSuscripcionNegocio : GenericNegocio<ClienteSuscripcionRequest, ClienteSuscripcionResponse, long>, IClienteSuscripcionNegocio
    {
        public ClienteSuscripcionNegocio(IClienteSuscripcionRepositorio clienteSuscripcionRepositorio) 
            : base(clienteSuscripcionRepositorio)
        {
        }
    }
}
