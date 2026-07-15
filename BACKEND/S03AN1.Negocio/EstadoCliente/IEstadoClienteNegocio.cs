using S03AN1.Modelos.EstadoCliente;
using S03AN1.Modelos.General;

namespace S03AN1.Negocio.EstadoCliente
{

    /*
        Una interfaz en C# es un contrato que define un conjunto de métodos, 
        propiedades, eventos o indexadores que una clase debe implementar. 
        Las interfaces permiten definir la estructura y el comportamiento 
        que una clase debe seguir sin proporcionar una implementación concreta.
     */


    public interface IEstadoClienteNegocio
    {
        /// <summary>
        /// Obtiene todos los estados de cliente.
        /// </summary>
        /// <returns></returns>
        Task<GeneralResponse<List<EstadoClienteResponse>>> GetAll();
        /// <summary>
        /// Obtiene un estado de cliente por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GeneralResponse<EstadoClienteResponse>> GetById(int id);
        /// <summary>
        /// Crea un nuevo estado de cliente.
        /// </summary>
        /// <param name="request">Datos del estado de cliente a crear.</param>
        /// <returns>El estado de cliente creado.</returns>
        Task<GeneralResponse<EstadoClienteResponse>> Create(EstadoClienteRequest request);
        /// <summary>
        /// Actualiza un estado de cliente existente por su ID.
        /// </summary>
        /// <param name="id">ID del estado de cliente a actualizar.</param>
        /// <param name="request">Datos del estado de cliente a actualizar.</param>
        /// <returns>El estado de cliente actualizado.</returns>
        Task<GeneralResponse<EstadoClienteResponse>> Update(int id, EstadoClienteRequest request);
        /// <summary>
        /// Elimina un estado de cliente por su ID.
        /// </summary>
        /// <param name="id">ID del estado de cliente a eliminar.</param>
        /// <returns>Indica si la eliminación fue exitosa.</returns>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
