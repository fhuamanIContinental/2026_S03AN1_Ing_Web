using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.EstadoSuscripcion;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.EstadoSuscripcion
{
    public class EstadoSuscripcionRepositorio : GenericRepositorio<DboEstadoSuscripcion, EstadoSuscripcionRequest, EstadoSuscripcionResponse, int>, IEstadoSuscripcionRepositorio
    {
        protected override EstadoSuscripcionResponse MapToResponse(DboEstadoSuscripcion entity)
        {
            return new EstadoSuscripcionResponse
            {
                Id = entity.Id,
                Codigo = entity.Codigo,
                Descripcion = entity.Descripcion
            };
        }

        protected override DboEstadoSuscripcion MapToEntity(EstadoSuscripcionRequest request)
        {
            return new DboEstadoSuscripcion
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Descripcion = request.Descripcion
            };
        }

        protected override void UpdateEntity(DboEstadoSuscripcion entity, EstadoSuscripcionRequest request)
        {
            entity.Codigo = request.Codigo;
            entity.Descripcion = request.Descripcion;
        }
    }
}
