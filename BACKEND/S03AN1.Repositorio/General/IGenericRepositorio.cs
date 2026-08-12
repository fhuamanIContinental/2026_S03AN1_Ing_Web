using S03AN1.Modelos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.General
{
    public interface IGenericRepositorio<TRequest, TResponse, TId> where TResponse : class
    {
        Task<List<TResponse>> GetAll();
        Task<PaginatedResponse<TResponse>> GetPaginated(int pageNumber, int pageSize);
        Task<TResponse?> GetById(TId id);
        Task<TResponse?> Create(TRequest request);
        Task<TResponse?> Update(TId id, TRequest request);
        Task<bool> Delete(TId id);
    }
}
