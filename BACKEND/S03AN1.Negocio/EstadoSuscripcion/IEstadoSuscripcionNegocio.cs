using S03AN1.Modelos.EstadoSuscripcion;
using S03AN1.Modelos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.EstadoSuscripcion
{
    public interface IEstadoSuscripcionNegocio
    {
        /// <summary>
        /// Obtiene todos los estados de suscripción.
        /// </summary>
        Task<GeneralResponse<List<EstadoSuscripcionResponse>>> GetAll();

        /// <summary>
        /// Obtiene un estado de suscripción por su ID.
        /// </summary>
        Task<GeneralResponse<EstadoSuscripcionResponse?>> GetById(int id);

        /// <summary>
        /// Crea un nuevo estado de suscripción.
        /// </summary>
        Task<GeneralResponse<EstadoSuscripcionResponse?>> Create(EstadoSuscripcionRequest request);

        /// <summary>
        /// Actualiza un estado de suscripción existente por su ID.
        /// </summary>
        Task<GeneralResponse<EstadoSuscripcionResponse?>> Update(int id, EstadoSuscripcionRequest request);

        /// <summary>
        /// Elimina un estado de suscripción por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
