using S03AN1.Modelos.Cliente;
using S03AN1.Modelos.General;
using S03AN1.Repositorio.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        #region variables y constructor
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteNegocio(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<ClienteResponse>>> GetAll()
        {
            List<ClienteResponse> lista = await _clienteRepositorio.GetAll();
            return new GeneralResponse<List<ClienteResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Clientes obtenidos correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<ClienteResponse?>> GetById(int id)
        {
            ClienteResponse? response = await _clienteRepositorio.GetById(id);
            return new GeneralResponse<ClienteResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Cliente no encontrado",
                TitleMessage = response != null ? "Cliente obtenido correctamente" : "Error al obtener cliente",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<ClienteResponse?>> Create(ClienteRequest request)
        {
            ClienteResponse? response = await _clienteRepositorio.Create(request);
            return new GeneralResponse<ClienteResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear cliente",
                TitleMessage = response != null ? "Cliente creado correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<ClienteResponse?>> Update(int id, ClienteRequest request)
        {
            ClienteResponse? response = await _clienteRepositorio.Update(id, request);
            return new GeneralResponse<ClienteResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Cliente no encontrado para actualizar",
                TitleMessage = response != null ? "Cliente actualizado correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _clienteRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Cliente no encontrado para eliminar",
                TitleMessage = result ? "Cliente eliminado correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
