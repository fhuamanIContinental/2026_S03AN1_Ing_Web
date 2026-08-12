using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<ClienteResponse>> GetAll()
        {
            List<DboCliente> listaBd = await _db.DboCliente.ToListAsync();

            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<ClienteResponse?> GetById(int id)
        {
            DboCliente? dbres = await _db.DboCliente.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<ClienteResponse?> Create(ClienteRequest request)
        {
            DboCliente newObject = new DboCliente
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

            await _db.DboCliente.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<ClienteResponse?> Update(int id, ClienteRequest request)
        {
            DboCliente? dbres = await _db.DboCliente.FindAsync(id);
            if (dbres is null) return null;

            dbres.Ruc = request.Ruc;
            dbres.Codigo = request.Codigo;
            dbres.RazonSocial = request.RazonSocial;
            dbres.NombreComercial = request.NombreComercial;
            dbres.Direccion = request.Direccion;
            dbres.Telefono = request.Telefono;
            dbres.CorreoContacto = request.CorreoContacto;
            dbres.ServidorSql = request.ServidorSql;
            dbres.BdNombre = request.BdNombre;
            dbres.BdUsuario = request.BdUsuario;
            dbres.BdPasswordCifrada = request.BdPasswordCifrada;
            dbres.IdEstado = request.IdEstado;
            dbres.FechaActivacion = request.FechaActivacion;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;

            _db.DboCliente.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(int id)
        {
            DboCliente? dbres = await _db.DboCliente.FindAsync(id);
            if (dbres is null) return false;

            _db.DboCliente.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static ClienteResponse MapToResponse(DboCliente x)
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
    }
}
