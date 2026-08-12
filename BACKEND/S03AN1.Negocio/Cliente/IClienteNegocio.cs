using S03AN1.Modelos.Cliente;
using S03AN1.Modelos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        Task<GeneralResponse<List<ClienteResponse>>> GetAll();

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        Task<GeneralResponse<ClienteResponse?>> GetById(int id);

        /// <summary>
        /// Crea un nuevo cliente.
        /// </summary>
        Task<GeneralResponse<ClienteResponse?>> Create(ClienteRequest request);

        /// <summary>
        /// Actualiza un cliente existente por su ID.
        /// </summary>
        Task<GeneralResponse<ClienteResponse?>> Update(int id, ClienteRequest request);

        /// <summary>
        /// Elimina un cliente por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
