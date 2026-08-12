using S03AN1.Modelos.General;
using S03AN1.Modelos.Persona;
using S03AN1.Repositorio.Persona;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Negocio.Persona
{
    public class PersonaNegocio : IPersonaNegocio
    {
        #region variables y constructor
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaNegocio(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }
        #endregion

        public async Task<GeneralResponse<List<PersonaResponse>>> GetAll()
        {
            List<PersonaResponse> lista = await _personaRepositorio.GetAll();
            return new GeneralResponse<List<PersonaResponse>>
            {
                Content = lista,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Personas obtenidas correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<PersonaResponse?>> GetById(int id)
        {
            PersonaResponse? response = await _personaRepositorio.GetById(id);
            return new GeneralResponse<PersonaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Persona no encontrada",
                TitleMessage = response != null ? "Persona obtenida correctamente" : "Error al obtener persona",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<PersonaResponse?>> Create(PersonaRequest request)
        {
            PersonaResponse? response = await _personaRepositorio.Create(request);
            return new GeneralResponse<PersonaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Error al crear persona",
                TitleMessage = response != null ? "Persona creada correctamente" : "Error de registro",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<PersonaResponse?>> Update(int id, PersonaRequest request)
        {
            PersonaResponse? response = await _personaRepositorio.Update(id, request);
            return new GeneralResponse<PersonaResponse?>
            {
                Content = response,
                Success = response != null,
                TextMessage = response != null ? "Operación exitosa" : "Persona no encontrada para actualizar",
                TitleMessage = response != null ? "Persona actualizada correctamente" : "Error de actualización",
                ShowAlert = response == null
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _personaRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = result,
                TextMessage = result ? "Operación exitosa" : "Persona no encontrada para eliminar",
                TitleMessage = result ? "Persona eliminada correctamente" : "Error de eliminación",
                ShowAlert = !result
            };
        }
    }
}
