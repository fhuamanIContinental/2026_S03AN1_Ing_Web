using S03AN1.Modelos.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Cliente
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteResponse>> GetAll();
        Task<ClienteResponse?> GetById(int id);
        Task<ClienteResponse?> Create(ClienteRequest request);
        Task<ClienteResponse?> Update(int id, ClienteRequest request);
        Task<bool> Delete(int id);
    }
}
