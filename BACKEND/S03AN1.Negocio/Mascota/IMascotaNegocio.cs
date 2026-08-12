using S03AN1.Modelos.Mascota;
using S03AN1.Negocio.General;

namespace S03AN1.Negocio.Mascota
{
    public interface IMascotaNegocio : IGenericNegocio<MascotaRequest, MascotaResponse, int>
    {
    }
}
