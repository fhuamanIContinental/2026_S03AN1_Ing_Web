using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.UsuarioPlataforma;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.UsuarioPlataforma
{
    public class UsuarioPlataformaRepositorio : GenericRepositorio<DboUsuarioPlataforma, UsuarioPlataformaRequest, UsuarioPlataformaResponse, long>, IUsuarioPlataformaRepositorio
    {
        protected override UsuarioPlataformaResponse MapToResponse(DboUsuarioPlataforma x)
        {
            return new UsuarioPlataformaResponse
            {
                Id = x.Id,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                Correo = x.Correo,
                ClaveCifrada = x.ClaveCifrada,
                IntentosFallidos = x.IntentosFallidos,
                BloqueadoHasta = x.BloqueadoHasta,
                UltimoAcceso = x.UltimoAcceso,
                Estado = x.Estado,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }

        protected override DboUsuarioPlataforma MapToEntity(UsuarioPlataformaRequest request)
        {
            return new DboUsuarioPlataforma
            {
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Correo = request.Correo,
                ClaveCifrada = request.ClaveCifrada,
                IntentosFallidos = request.IntentosFallidos,
                BloqueadoHasta = request.BloqueadoHasta,
                UltimoAcceso = request.UltimoAcceso,
                Estado = request.Estado,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };
        }

        protected override void UpdateEntity(DboUsuarioPlataforma dbres, UsuarioPlataformaRequest request)
        {
            dbres.Nombres = request.Nombres;
            dbres.Apellidos = request.Apellidos;
            dbres.Correo = request.Correo;
            dbres.ClaveCifrada = request.ClaveCifrada;
            dbres.IntentosFallidos = request.IntentosFallidos;
            dbres.BloqueadoHasta = request.BloqueadoHasta;
            dbres.UltimoAcceso = request.UltimoAcceso;
            dbres.Estado = request.Estado;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;
        }
    }
}
