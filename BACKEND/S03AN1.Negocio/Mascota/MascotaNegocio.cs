using S03AN1.Modelos.General;
using S03AN1.Modelos.Mascota;
using S03AN1.Repositorio.Mascota;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Mascota
{
    public class MascotaNegocio : IMascotaNegocio
    {
        #region variables y constructor
        private readonly IMascotaRepositorio _mascotaRepositorio;

        public MascotaNegocio(IMascotaRepositorio mascotaRepositorio)
        {
            _mascotaRepositorio = mascotaRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<MascotaResponse>>> GetAll()
        {
            List<MascotaResponse> lista = await _mascotaRepositorio.GetAll();
            return new GeneralResponse<List<MascotaResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Mascotas obtenidas correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<MascotaResponse?>> GetById(int id)
        {
            MascotaResponse? response = await _mascotaRepositorio.GetById(id);
            return new GeneralResponse<MascotaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Mascota no encontrada",
                TitleMessage = response != null ? "Mascota obtenida correctamente" : "Error al obtener mascota",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<MascotaResponse?>> Create(MascotaRequest request)
        {
            MascotaResponse? response = await _mascotaRepositorio.Create(request);
            return new GeneralResponse<MascotaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear mascota",
                TitleMessage = response != null ? "Mascota creada correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<MascotaResponse?>> Update(int id, MascotaRequest request)
        {
            MascotaResponse? response = await _mascotaRepositorio.Update(id, request);
            return new GeneralResponse<MascotaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Mascota no encontrada para actualizar",
                TitleMessage = response != null ? "Mascota actualizada correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _mascotaRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Mascota no encontrada para eliminar",
                TitleMessage = result ? "Mascota eliminada correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
