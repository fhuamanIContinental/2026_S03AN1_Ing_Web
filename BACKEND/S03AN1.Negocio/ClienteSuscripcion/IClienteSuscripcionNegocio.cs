using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Modelos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.ClienteSuscripcion
{
    public interface IClienteSuscripcionNegocio
    {
        /// <summary>
        /// Obtiene todas las suscripciones de clientes.
        /// </summary>
        Task<GeneralResponse<List<ClienteSuscripcionResponse>>> GetAll();

        /// <summary>
        /// Obtiene una suscripción por su ID.
        /// </summary>
        Task<GeneralResponse<ClienteSuscripcionResponse?>> GetById(long id);

        /// <summary>
        /// Crea una nueva suscripción de cliente.
        /// </summary>
        Task<GeneralResponse<ClienteSuscripcionResponse?>> Create(ClienteSuscripcionRequest request);

        /// <summary>
        /// Actualiza una suscripción de cliente existente por su ID.
        /// </summary>
        Task<GeneralResponse<ClienteSuscripcionResponse?>> Update(long id, ClienteSuscripcionRequest request);

        /// <summary>
        /// Elimina una suscripción por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(long id);
    }
}
