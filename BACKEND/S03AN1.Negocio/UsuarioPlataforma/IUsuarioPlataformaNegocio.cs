using S03AN1.Modelos.General;
using S03AN1.Modelos.UsuarioPlataforma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.UsuarioPlataforma
{
    public interface IUsuarioPlataformaNegocio
    {
        /// <summary>
        /// Obtiene todos los usuarios de la plataforma.
        /// </summary>
        Task<GeneralResponse<List<UsuarioPlataformaResponse>>> GetAll();

        /// <summary>
        /// Obtiene un usuario de plataforma por su ID.
        /// </summary>
        Task<GeneralResponse<UsuarioPlataformaResponse?>> GetById(long id);

        /// <summary>
        /// Crea un nuevo usuario de plataforma.
        /// </summary>
        Task<GeneralResponse<UsuarioPlataformaResponse?>> Create(UsuarioPlataformaRequest request);

        /// <summary>
        /// Actualiza un usuario de plataforma existente por su ID.
        /// </summary>
        Task<GeneralResponse<UsuarioPlataformaResponse?>> Update(long id, UsuarioPlataformaRequest request);

        /// <summary>
        /// Elimina un usuario de plataforma por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(long id);
    }
}
