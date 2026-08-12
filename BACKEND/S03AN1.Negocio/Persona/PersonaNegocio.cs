using S03AN1.Modelos.Persona;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.Persona;

namespace S03AN1.Negocio.Persona
{
    public class PersonaNegocio : GenericNegocio<PersonaRequest, PersonaResponse, int>, IPersonaNegocio
    {
        public PersonaNegocio(IPersonaRepositorio personaRepositorio) 
            : base(personaRepositorio)
        {
        }
    }
}
