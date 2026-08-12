using S03AN1.Modelos.EstadoSuscripcion;
using S03AN1.Negocio.General;
using S03AN1.Repositorio.EstadoSuscripcion;

namespace S03AN1.Negocio.EstadoSuscripcion
{
    public class EstadoSuscripcionNegocio : GenericNegocio<EstadoSuscripcionRequest, EstadoSuscripcionResponse, int>, IEstadoSuscripcionNegocio
    {
        public EstadoSuscripcionNegocio(IEstadoSuscripcionRepositorio estadoSuscripcionRepositorio) 
            : base(estadoSuscripcionRepositorio)
        {
        }
    }
}
