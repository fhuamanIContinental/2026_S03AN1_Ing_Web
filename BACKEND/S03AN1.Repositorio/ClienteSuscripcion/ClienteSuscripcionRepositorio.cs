using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.ClienteSuscripcion
{
    public class ClienteSuscripcionRepositorio : GenericRepositorio<DboClienteSuscripcion, ClienteSuscripcionRequest, ClienteSuscripcionResponse, long>, IClienteSuscripcionRepositorio
    {
        protected override ClienteSuscripcionResponse MapToResponse(DboClienteSuscripcion x)
        {
            return new ClienteSuscripcionResponse
            {
                Id = x.Id,
                IdCliente = x.IdCliente,
                IdPlan = x.IdPlan,
                FechaInicio = x.FechaInicio,
                FechaFin = x.FechaFin,
                Modalidad = x.Modalidad,
                MontoPactado = x.MontoPactado,
                IdEstado = x.IdEstado,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }

        protected override DboClienteSuscripcion MapToEntity(ClienteSuscripcionRequest request)
        {
            return new DboClienteSuscripcion
            {
                IdCliente = request.IdCliente,
                IdPlan = request.IdPlan,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Modalidad = request.Modalidad,
                MontoPactado = request.MontoPactado,
                IdEstado = request.IdEstado,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };
        }

        protected override void UpdateEntity(DboClienteSuscripcion dbres, ClienteSuscripcionRequest request)
        {
            dbres.IdCliente = request.IdCliente;
            dbres.IdPlan = request.IdPlan;
            dbres.FechaInicio = request.FechaInicio;
            dbres.FechaFin = request.FechaFin;
            dbres.Modalidad = request.Modalidad;
            dbres.MontoPactado = request.MontoPactado;
            dbres.IdEstado = request.IdEstado;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;
        }
    }
}
