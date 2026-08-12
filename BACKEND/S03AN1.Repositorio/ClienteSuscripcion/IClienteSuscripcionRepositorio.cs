using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.ClienteSuscripcion
{
    public interface IClienteSuscripcionRepositorio : IGenericRepositorio<ClienteSuscripcionRequest, ClienteSuscripcionResponse, long>
    {
    }
}
