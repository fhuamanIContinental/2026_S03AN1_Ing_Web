using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Modelos.General;
using S03AN1.Repositorio.ClienteSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.ClienteSuscripcion
{
    public class ClienteSuscripcionNegocio : IClienteSuscripcionNegocio
    {
        #region variables y constructor
        private readonly IClienteSuscripcionRepositorio _clienteSuscripcionRepositorio;

        public ClienteSuscripcionNegocio(IClienteSuscripcionRepositorio clienteSuscripcionRepositorio)
        {
            _clienteSuscripcionRepositorio = clienteSuscripcionRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<ClienteSuscripcionResponse>>> GetAll()
        {
            List<ClienteSuscripcionResponse> lista = await _clienteSuscripcionRepositorio.GetAll();
            return new GeneralResponse<List<ClienteSuscripcionResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Suscripciones de clientes obtenidas correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<ClienteSuscripcionResponse?>> GetById(long id)
        {
            ClienteSuscripcionResponse? response = await _clienteSuscripcionRepositorio.GetById(id);
            return new GeneralResponse<ClienteSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Suscripción no encontrada",
                TitleMessage = response != null ? "Suscripción obtenida correctamente" : "Error al obtener suscripción",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<ClienteSuscripcionResponse?>> Create(ClienteSuscripcionRequest request)
        {
            ClienteSuscripcionResponse? response = await _clienteSuscripcionRepositorio.Create(request);
            return new GeneralResponse<ClienteSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear suscripción",
                TitleMessage = response != null ? "Suscripción creada correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<ClienteSuscripcionResponse?>> Update(long id, ClienteSuscripcionRequest request)
        {
            ClienteSuscripcionResponse? response = await _clienteSuscripcionRepositorio.Update(id, request);
            return new GeneralResponse<ClienteSuscripcionResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Suscripción no encontrada para actualizar",
                TitleMessage = response != null ? "Suscripción actualizada correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(long id)
        {
            bool result = await _clienteSuscripcionRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Suscripción no encontrada para eliminar",
                TitleMessage = result ? "Suscripción eliminada correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
