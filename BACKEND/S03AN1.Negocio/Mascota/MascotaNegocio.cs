using S03AN1.Modelos.Mascota;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.Mascota;

namespace S03AN1.Negocio.Mascota
{
    public class MascotaNegocio : GenericNegocio<MascotaRequest, MascotaResponse, int>, IMascotaNegocio
    {
        public MascotaNegocio(IMascotaRepositorio mascotaRepositorio) 
            : base(mascotaRepositorio)
        {
        }
    }
}
