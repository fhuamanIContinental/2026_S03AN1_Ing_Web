using S03AN1.Modelos.Persona;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.Persona
{
    public class PersonaRepositorio : GenericRepositorio<DbModel.DbColegio.Persona, PersonaRequest, PersonaResponse, int>, IPersonaRepositorio
    {
        protected override PersonaResponse MapToResponse(DbModel.DbColegio.Persona x)
        {
            return new PersonaResponse
            {
                Id = x.Id,
                TipoDocumento = x.TipoDocumento,
                NumeroDocumento = x.NumeroDocumento,
                Nombres = x.Nombres,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }

        protected override DbModel.DbColegio.Persona MapToEntity(PersonaRequest request)
        {
            return new DbModel.DbColegio.Persona
            {
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };
        }

        protected override void UpdateEntity(DbModel.DbColegio.Persona dbres, PersonaRequest request)
        {
            dbres.TipoDocumento = request.TipoDocumento;
            dbres.NumeroDocumento = request.NumeroDocumento;
            dbres.Nombres = request.Nombres;
            dbres.ApellidoPaterno = request.ApellidoPaterno;
            dbres.ApellidoMaterno = request.ApellidoMaterno;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;
        }
    }
}
