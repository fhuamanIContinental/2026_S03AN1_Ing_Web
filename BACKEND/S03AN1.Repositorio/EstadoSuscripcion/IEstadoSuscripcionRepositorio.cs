using S03AN1.Modelos.EstadoSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.EstadoSuscripcion
{
    public interface IEstadoSuscripcionRepositorio
    {
        Task<List<EstadoSuscripcionResponse>> GetAll();
        Task<EstadoSuscripcionResponse?> GetById(int id);
        Task<EstadoSuscripcionResponse?> Create(EstadoSuscripcionRequest request);
        Task<EstadoSuscripcionResponse?> Update(int id, EstadoSuscripcionRequest request);
        Task<bool> Delete(int id);
    }
}
