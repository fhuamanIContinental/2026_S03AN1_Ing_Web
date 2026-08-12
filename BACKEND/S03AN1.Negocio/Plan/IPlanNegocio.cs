using S03AN1.Modelos.General;
using S03AN1.Modelos.Plan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Plan
{
    public interface IPlanNegocio
    {
        /// <summary>
        /// Obtiene todos los planes.
        /// </summary>
        Task<GeneralResponse<List<PlanResponse>>> GetAll();

        /// <summary>
        /// Obtiene un plan por su ID.
        /// </summary>
        Task<GeneralResponse<PlanResponse?>> GetById(int id);

        /// <summary>
        /// Crea un nuevo plan.
        /// </summary>
        Task<GeneralResponse<PlanResponse?>> Create(PlanRequest request);

        /// <summary>
        /// Actualiza un plan existente por su ID.
        /// </summary>
        Task<GeneralResponse<PlanResponse?>> Update(int id, PlanRequest request);

        /// <summary>
        /// Elimina un plan por su ID.
        /// </summary>
        Task<GeneralResponse<bool>> Delete(int id);
    }
}
