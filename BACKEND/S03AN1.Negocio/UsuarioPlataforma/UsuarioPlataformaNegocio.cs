using S03AN1.Modelos.General;
using S03AN1.Modelos.UsuarioPlataforma;
using S03AN1.Repositorio.UsuarioPlataforma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.UsuarioPlataforma
{
    public class UsuarioPlataformaNegocio : IUsuarioPlataformaNegocio
    {
        #region variables y constructor
        private readonly IUsuarioPlataformaRepositorio _usuarioPlataformaRepositorio;

        public UsuarioPlataformaNegocio(IUsuarioPlataformaRepositorio usuarioPlataformaRepositorio)
        {
            _usuarioPlataformaRepositorio = usuarioPlataformaRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<UsuarioPlataformaResponse>>> GetAll()
        {
            List<UsuarioPlataformaResponse> lista = await _usuarioPlataformaRepositorio.GetAll();
            return new GeneralResponse<List<UsuarioPlataformaResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Usuarios de plataforma obtenidos correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<UsuarioPlataformaResponse?>> GetById(long id)
        {
            UsuarioPlataformaResponse? response = await _usuarioPlataformaRepositorio.GetById(id);
            return new GeneralResponse<UsuarioPlataformaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Usuario no encontrado",
                TitleMessage = response != null ? "Usuario obtenido correctamente" : "Error al obtener usuario",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<UsuarioPlataformaResponse?>> Create(UsuarioPlataformaRequest request)
        {
            UsuarioPlataformaResponse? response = await _usuarioPlataformaRepositorio.Create(request);
            return new GeneralResponse<UsuarioPlataformaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear usuario",
                TitleMessage = response != null ? "Usuario creado correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<UsuarioPlataformaResponse?>> Update(long id, UsuarioPlataformaRequest request)
        {
            UsuarioPlataformaResponse? response = await _usuarioPlataformaRepositorio.Update(id, request);
            return new GeneralResponse<UsuarioPlataformaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Usuario no encontrado para actualizar",
                TitleMessage = response != null ? "Usuario actualizado correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(long id)
        {
            bool result = await _usuarioPlataformaRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Usuario no encontrado para eliminar",
                TitleMessage = result ? "Usuario eliminado correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
