using S03AN1.Modelos.Persona;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Persona
{
    public interface IPersonaRepositorio
    {
        Task<List<PersonaResponse>> GetAll();
        Task<PersonaResponse?> GetById(int id);
        Task<PersonaResponse?> Create(PersonaRequest request);
        Task<PersonaResponse?> Update(int id, PersonaRequest request);
        Task<bool> Delete(int id);
    }
}
