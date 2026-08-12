using S03AN1.Modelos.Plan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Plan
{
    public interface IPlanRepositorio
    {
        Task<List<PlanResponse>> GetAll();
        Task<PlanResponse?> GetById(int id);
        Task<PlanResponse?> Create(PlanRequest request);
        Task<PlanResponse?> Update(int id, PlanRequest request);
        Task<bool> Delete(int id);
    }
}
