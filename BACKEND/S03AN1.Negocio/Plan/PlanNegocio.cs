using S03AN1.Modelos.General;
using S03AN1.Modelos.Plan;
using S03AN1.Repositorio.Plan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Plan
{
    public class PlanNegocio : IPlanNegocio
    {
        #region variables y constructor
        private readonly IPlanRepositorio _planRepositorio;

        public PlanNegocio(IPlanRepositorio planRepositorio)
        {
            _planRepositorio = planRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<PlanResponse>>> GetAll()
        {
            List<PlanResponse> lista = await _planRepositorio.GetAll();
            return new GeneralResponse<List<PlanResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Planes obtenidos correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<PlanResponse?>> GetById(int id)
        {
            PlanResponse? response = await _planRepositorio.GetById(id);
            return new GeneralResponse<PlanResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Plan no encontrado",
                TitleMessage = response != null ? "Plan obtenido correctamente" : "Error al obtener plan",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<PlanResponse?>> Create(PlanRequest request)
        {
            PlanResponse? response = await _planRepositorio.Create(request);
            return new GeneralResponse<PlanResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear plan",
                TitleMessage = response != null ? "Plan creado correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<PlanResponse?>> Update(int id, PlanRequest request)
        {
            PlanResponse? response = await _planRepositorio.Update(id, request);
            return new GeneralResponse<PlanResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Plan no encontrado para actualizar",
                TitleMessage = response != null ? "Plan actualizado correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _planRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Plan no encontrado para eliminar",
                TitleMessage = result ? "Plan eliminado correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
