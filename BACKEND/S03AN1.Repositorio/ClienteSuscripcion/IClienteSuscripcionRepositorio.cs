using S03AN1.Modelos.ClienteSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.ClienteSuscripcion
{
    public interface IClienteSuscripcionRepositorio
    {
        Task<List<ClienteSuscripcionResponse>> GetAll();
        Task<ClienteSuscripcionResponse?> GetById(long id);
        Task<ClienteSuscripcionResponse?> Create(ClienteSuscripcionRequest request);
        Task<ClienteSuscripcionResponse?> Update(long id, ClienteSuscripcionRequest request);
        Task<bool> Delete(long id);
    }
}
