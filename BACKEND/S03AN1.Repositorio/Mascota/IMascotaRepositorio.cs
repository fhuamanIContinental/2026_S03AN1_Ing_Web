using S03AN1.Modelos.Mascota;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.Mascota
{
    public interface IMascotaRepositorio : IGenericRepositorio<MascotaRequest, MascotaResponse, int>
    {
    }
}
