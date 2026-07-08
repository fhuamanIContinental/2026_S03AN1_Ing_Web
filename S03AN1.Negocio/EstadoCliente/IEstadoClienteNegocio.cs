using S03AN1.Modelos.EstadoCliente;

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
        Task<List<EstadoClienteResponse>> GetAll();
        /// <summary>
        /// Obtiene un estado de cliente por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EstadoClienteResponse> GetById(int id);
        /// <summary>
        /// Crea un nuevo estado de cliente.
        /// </summary>
        /// <param name="request">Datos del estado de cliente a crear.</param>
        /// <returns>El estado de cliente creado.</returns>
        Task<EstadoClienteResponse> Create(EstadoClienteRequest request);
        /// <summary>
        /// Actualiza un estado de cliente existente por su ID.
        /// </summary>
        /// <param name="id">ID del estado de cliente a actualizar.</param>
        /// <param name="request">Datos del estado de cliente a actualizar.</param>
        /// <returns>El estado de cliente actualizado.</returns>
        Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request);
        /// <summary>
        /// Elimina un estado de cliente por su ID.
        /// </summary>
        /// <param name="id">ID del estado de cliente a eliminar.</param>
        /// <returns>Indica si la eliminación fue exitosa.</returns>
        Task<bool> Delete(int id);
    }
}
