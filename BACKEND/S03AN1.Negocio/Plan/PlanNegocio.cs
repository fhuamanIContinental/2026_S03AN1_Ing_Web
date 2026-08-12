using S03AN1.Modelos.Plan;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.Plan;

namespace S03AN1.Negocio.Plan
{
    public class PlanNegocio : GenericNegocio<PlanRequest, PlanResponse, int>, IPlanNegocio
    {
        public PlanNegocio(IPlanRepositorio planRepositorio) 
            : base(planRepositorio)
        {
        }
    }
}
