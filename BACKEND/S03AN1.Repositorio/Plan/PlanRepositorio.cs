using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Plan;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.Plan
{
    public class PlanRepositorio : GenericRepositorio<DboPlan, PlanRequest, PlanResponse, int>, IPlanRepositorio
    {
        protected override PlanResponse MapToResponse(DboPlan x)
        {
            return new PlanResponse
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
                PrecioMensual = x.PrecioMensual,
                PrecioAnual = x.PrecioAnual,
                MaxEstudiante = x.MaxEstudiante,
                MaxUsuario = x.MaxUsuario,
                Estado = x.Estado,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion,
                CampoPrueba = x.CampoPrueba
            };
        }

        protected override DboPlan MapToEntity(PlanRequest request)
        {
            return new DboPlan
            {
                Codigo = request.Codigo,
                Nombre = request.Nombre,
                PrecioMensual = request.PrecioMensual,
                PrecioAnual = request.PrecioAnual,
                MaxEstudiante = request.MaxEstudiante,
                MaxUsuario = request.MaxUsuario,
                Estado = request.Estado,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion,
                CampoPrueba = request.CampoPrueba
            };
        }

        protected override void UpdateEntity(DboPlan dbres, PlanRequest request)
        {
            dbres.Codigo = request.Codigo;
            dbres.Nombre = request.Nombre;
            dbres.PrecioMensual = request.PrecioMensual;
            dbres.PrecioAnual = request.PrecioAnual;
            dbres.MaxEstudiante = request.MaxEstudiante;
            dbres.MaxUsuario = request.MaxUsuario;
            dbres.Estado = request.Estado;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;
            dbres.CampoPrueba = request.CampoPrueba;
        }
    }
}
