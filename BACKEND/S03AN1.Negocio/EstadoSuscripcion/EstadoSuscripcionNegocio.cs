using S03AN1.Modelos.EstadoSuscripcion;
using S03AN1.Modelos.General;
using S03AN1.Repositorio.EstadoSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.EstadoSuscripcion
{
    public class EstadoSuscripcionNegocio : IEstadoSuscripcionNegocio
    {
        #region variables y constructor
        private readonly IEstadoSuscripcionRepositorio _estadoSuscripcionRepositorio;

        public EstadoSuscripcionNegocio(IEstadoSuscripcionRepositorio estadoSuscripcionRepositorio)
        {
            _estadoSuscripcionRepositorio = estadoSuscripcionRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<EstadoSuscripcionResponse>>> GetAll()
        {
            List<EstadoSuscripcionResponse> lista = await _estadoSuscripcionRepositorio.GetAll();
            return new GeneralResponse<List<EstadoSuscripcionResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estados de suscripción obtenidos correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<EstadoSuscripcionResponse?>> GetById(int id)
        {
            EstadoSuscripcionResponse? response = await _estadoSuscripcionRepositorio.GetById(id);
            return new GeneralResponse<EstadoSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Estado de suscripción no encontrado",
                TitleMessage = response != null ? "Estado de suscripción obtenido correctamente" : "Error al obtener estado de suscripción",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<EstadoSuscripcionResponse?>> Create(EstadoSuscripcionRequest request)
        {
            EstadoSuscripcionResponse? response = await _estadoSuscripcionRepositorio.Create(request);
            return new GeneralResponse<EstadoSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear estado de suscripción",
                TitleMessage = response != null ? "Estado de suscripción creado correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<EstadoSuscripcionResponse?>> Update(int id, EstadoSuscripcionRequest request)
        {
            EstadoSuscripcionResponse? response = await _estadoSuscripcionRepositorio.Update(id, request);
            return new GeneralResponse<EstadoSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Estado de suscripción no encontrado para actualizar",
                TitleMessage = response != null ? "Estado de suscripción actualizado correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _estadoSuscripcionRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Estado de suscripción no encontrado para eliminar",
                TitleMessage = result ? "Estado de suscripción eliminado correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
