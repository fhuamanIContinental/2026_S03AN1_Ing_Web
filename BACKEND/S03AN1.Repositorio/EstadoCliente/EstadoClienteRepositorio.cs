using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.EstadoCliente;
using S03AN1.Repositorio.General;

namespace S03AN1.Repositorio.EstadoCliente
{
    public class EstadoClienteRepositorio : GenericRepositorio<DboEstadoCliente, EstadoClienteRequest, EstadoClienteResponse, int>, IEstadoClienteRepositorio
    {
        protected override EstadoClienteResponse MapToResponse(DboEstadoCliente entity)
        {
            return new EstadoClienteResponse
            {
                Id = entity.Id,
                Codigo = entity.Codigo,
                Descripcion = entity.Descripcion
            };
        }

        protected override DboEstadoCliente MapToEntity(EstadoClienteRequest request)
        {
            return new DboEstadoCliente
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Descripcion = request.Descripcion
            };
        }

        protected override void UpdateEntity(DboEstadoCliente entity, EstadoClienteRequest request)
        {
            entity.Codigo = request.Codigo;
            entity.Descripcion = request.Descripcion;
        }
    }
}