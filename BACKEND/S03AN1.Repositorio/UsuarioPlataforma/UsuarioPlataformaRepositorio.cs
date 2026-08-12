using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.UsuarioPlataforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.UsuarioPlataforma
{
    public class UsuarioPlataformaRepositorio : IUsuarioPlataformaRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<UsuarioPlataformaResponse>> GetAll()
        {
            List<DboUsuarioPlataforma> listaBd = await _db.DboUsuarioPlataforma.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<UsuarioPlataformaResponse?> GetById(long id)
        {
            DboUsuarioPlataforma? dbres = await _db.DboUsuarioPlataforma.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<UsuarioPlataformaResponse?> Create(UsuarioPlataformaRequest request)
        {
            DboUsuarioPlataforma newObject = new DboUsuarioPlataforma
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

            await _db.DboUsuarioPlataforma.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<UsuarioPlataformaResponse?> Update(long id, UsuarioPlataformaRequest request)
        {
            DboUsuarioPlataforma? dbres = await _db.DboUsuarioPlataforma.FindAsync(id);
            if (dbres is null) return null;

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

            _db.DboUsuarioPlataforma.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(long id)
        {
            DboUsuarioPlataforma? dbres = await _db.DboUsuarioPlataforma.FindAsync(id);
            if (dbres is null) return false;

            _db.DboUsuarioPlataforma.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static UsuarioPlataformaResponse MapToResponse(DboUsuarioPlataforma x)
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
    }
}
