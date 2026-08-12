using S03AN1.Modelos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.General
{
    public interface IGenericNegocio<TRequest, TResponse, TId> where TResponse : class
    {
        Task<GeneralResponse<List<TResponse>>> GetAll();
        Task<GeneralResponse<PaginatedResponse<TResponse>>> GetPaginated(int pageNumber, int pageSize);
        Task<GeneralResponse<TResponse?>> GetById(TId id);
        Task<GeneralResponse<TResponse?>> Create(TRequest request);
        Task<GeneralResponse<TResponse?>> Update(TId id, TRequest request);
        Task<GeneralResponse<bool>> Delete(TId id);
    }
}
