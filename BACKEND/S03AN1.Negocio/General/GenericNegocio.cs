using S03AN1.Modelos.General;
using S03AN1.Repositorio.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.General
{
    public class GenericNegocio<TRequest, TResponse, TId> : IGenericNegocio<TRequest, TResponse, TId>
        where TResponse : class
    {
        protected readonly IGenericRepositorio<TRequest, TResponse, TId> _repository;

        public GenericNegocio(IGenericRepositorio<TRequest, TResponse, TId> repository)
        {
            _repository = repository;
        }

        public virtual async Task<GeneralResponse<List<TResponse>>> GetAll()
        {
            List<TResponse> lista = await _repository.GetAll();
            return new GeneralResponse<List<TResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Registros obtenidos correctamente",
                ShowAlert = false
            };
        }

        public virtual async Task<GeneralResponse<PaginatedResponse<TResponse>>> GetPaginated(int pageNumber, int pageSize)
        {
            PaginatedResponse<TResponse> paginatedData = await _repository.GetPaginated(pageNumber, pageSize);
            return new GeneralResponse<PaginatedResponse<TResponse>>
            {
                Content = paginatedData,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Registros paginados obtenidos correctamente",
                ShowAlert = false
            };
        }

        public virtual async Task<GeneralResponse<TResponse?>> GetById(TId id)
        {
            TResponse? response = await _repository.GetById(id);
            return new GeneralResponse<TResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Registro no encontrado",
                TitleMessage = response != null ? "Registro obtenido correctamente" : "Error al obtener registro",
                ShowAlert = response == null
            };
        }

        public virtual async Task<GeneralResponse<TResponse?>> Create(TRequest request)
        {
            TResponse? response = await _repository.Create(request);
            return new GeneralResponse<TResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear registro",
                TitleMessage = response != null ? "Registro creado correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public virtual async Task<GeneralResponse<TResponse?>> Update(TId id, TRequest request)
        {
            TResponse? response = await _repository.Update(id, request);
            return new GeneralResponse<TResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Registro no encontrado para actualizar",
                TitleMessage = response != null ? "Registro actualizado correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public virtual async Task<GeneralResponse<bool>> Delete(TId id)
        {
            bool result = await _repository.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Registro no encontrado para eliminar",
                TitleMessage = result ? "Registro eliminado correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
