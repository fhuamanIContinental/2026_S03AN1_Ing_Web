using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Cliente;
using S03AN1.Repositorio.General;
using System;

namespace S03AN1.Repositorio.Cliente
{
    public class ClienteRepositorio : GenericRepositorio<DboCliente, ClienteRequest, ClienteResponse, int>, IClienteRepositorio
    {
        protected override ClienteResponse MapToResponse(DboCliente x)
        {
            return new ClienteResponse
            {
                Id = x.Id,
                Ruc = x.Ruc,
                Codigo = x.Codigo,
                RazonSocial = x.RazonSocial,
                NombreComercial = x.NombreComercial,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                CorreoContacto = x.CorreoContacto,
                ServidorSql = x.ServidorSql,
                BdNombre = x.BdNombre,
                BdUsuario = x.BdUsuario,
                BdPasswordCifrada = x.BdPasswordCifrada,
                IdEstado = x.IdEstado,
                FechaActivacion = x.FechaActivacion,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }

        protected override DboCliente MapToEntity(ClienteRequest request)
        {
            return new DboCliente
            {
                Ruc = request.Ruc,
                Codigo = request.Codigo,
                RazonSocial = request.RazonSocial,
                NombreComercial = request.NombreComercial,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                CorreoContacto = request.CorreoContacto,
                ServidorSql = request.ServidorSql,
                BdNombre = request.BdNombre,
                BdUsuario = request.BdUsuario,
                BdPasswordCifrada = request.BdPasswordCifrada,
                IdEstado = request.IdEstado,
                FechaActivacion = request.FechaActivacion,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };
        }

        protected override void UpdateEntity(DboCliente entity, ClienteRequest request)
        {
            entity.Ruc = request.Ruc;
            entity.Codigo = request.Codigo;
            entity.RazonSocial = request.RazonSocial;
            entity.NombreComercial = request.NombreComercial;
            entity.Direccion = request.Direccion;
            entity.Telefono = request.Telefono;
            entity.CorreoContacto = request.CorreoContacto;
            entity.ServidorSql = request.ServidorSql;
            entity.BdNombre = request.BdNombre;
            entity.BdUsuario = request.BdUsuario;
            entity.BdPasswordCifrada = request.BdPasswordCifrada;
            entity.IdEstado = request.IdEstado;
            entity.FechaActivacion = request.FechaActivacion;
            entity.FechaModificacion = DateTime.UtcNow;
            entity.UsuarioModificacion = request.UsuarioModificacion;
        }
    }
}
