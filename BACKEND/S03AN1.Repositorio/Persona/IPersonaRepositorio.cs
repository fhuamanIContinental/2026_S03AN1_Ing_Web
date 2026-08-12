using S03AN1.Modelos.Persona;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.Persona
{
    public interface IPersonaRepositorio : IGenericRepositorio<PersonaRequest, PersonaResponse, int>
    {
    }
}
