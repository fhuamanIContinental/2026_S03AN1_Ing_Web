using S03AN1.Modelos.Mascota;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.Mascota
{
    public class MascotaRepositorio : GenericRepositorio<DbModel.DbColegio.Mascota, MascotaRequest, MascotaResponse, int>, IMascotaRepositorio
    {
        protected override MascotaResponse MapToResponse(DbModel.DbColegio.Mascota x)
        {
            return new MascotaResponse
            {
                Id = x.Id,
                CategoriaMascota = x.CategoriaMascota,
                Raza = x.Raza,
                Edad = x.Edad,
                Nombre = x.Nombre,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }

        protected override DbModel.DbColegio.Mascota MapToEntity(MascotaRequest request)
        {
            return new DbModel.DbColegio.Mascota
            {
                CategoriaMascota = request.CategoriaMascota,
                Raza = request.Raza,
                Edad = request.Edad,
                Nombre = request.Nombre,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };
        }

        protected override void UpdateEntity(DbModel.DbColegio.Mascota dbres, MascotaRequest request)
        {
            dbres.CategoriaMascota = request.CategoriaMascota;
            dbres.Raza = request.Raza;
            dbres.Edad = request.Edad;
            dbres.Nombre = request.Nombre;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;
        }
    }
}
