using S03AN1.Modelos.UsuarioPlataforma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.UsuarioPlataforma
{
    public interface IUsuarioPlataformaRepositorio
    {
        Task<List<UsuarioPlataformaResponse>> GetAll();
        Task<UsuarioPlataformaResponse?> GetById(long id);
        Task<UsuarioPlataformaResponse?> Create(UsuarioPlataformaRequest request);
        Task<UsuarioPlataformaResponse?> Update(long id, UsuarioPlataformaRequest request);
        Task<bool> Delete(long id);
    }
}
