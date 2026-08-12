using S03AN1.Modelos.Mascota;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Mascota
{
    public interface IMascotaRepositorio
    {
        Task<List<MascotaResponse>> GetAll();
        Task<MascotaResponse?> GetById(int id);
        Task<MascotaResponse?> Create(MascotaRequest request);
        Task<MascotaResponse?> Update(int id, MascotaRequest request);
        Task<bool> Delete(int id);
    }
}
