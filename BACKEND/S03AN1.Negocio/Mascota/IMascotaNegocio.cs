using S03AN1.Modelos.General;
using S03AN1.Modelos.Mascota;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Mascota
{
    public interface IMascotaNegocio
    {
        /// <summary>
        /// Obtiene todas las mascotas.
        /// </summary>
        Task<GeneralResponse<List<MascotaResponse>>> GetAll();

        /// <summary>
        /// Obtiene una mascota por su ID.
        /// </summary>
        Task<GeneralResponse<MascotaResponse?>> GetById(int id);

        /// <summary>
        /// Crea una nueva mascota.
        /// </summary>
        Task<GeneralResponse<MascotaResponse?>> Create(MascotaRequest request);

        /// <summary>
        /// Actualiza una mascota existente por su ID.
        /// </summary>
        Task<GeneralResponse<MascotaResponse?>> Update(int id, MascotaRequest request);

        /// <summary>
        /// Elimina una mascota por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
