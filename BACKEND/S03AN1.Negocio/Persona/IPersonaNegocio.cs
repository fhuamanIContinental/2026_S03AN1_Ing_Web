using S03AN1.Modelos.General;
using S03AN1.Modelos.Persona;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Persona
{
    public interface IPersonaNegocio
    {
        /// <summary>
        /// Obtiene todas las personas.
        /// </summary>
        Task<GeneralResponse<List<PersonaResponse>>> GetAll();

        /// <summary>
        /// Obtiene una persona por su ID.
        /// </summary>
        Task<GeneralResponse<PersonaResponse?>> GetById(int id);

        /// <summary>
        /// Crea una nueva persona.
        /// </summary>
        Task<GeneralResponse<PersonaResponse?>> Create(PersonaRequest request);

        /// <summary>
        /// Actualiza una persona existente por su ID.
        /// </summary>
        Task<GeneralResponse<PersonaResponse?>> Update(int id, PersonaRequest request);

        /// <summary>
        /// Elimina una persona por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
