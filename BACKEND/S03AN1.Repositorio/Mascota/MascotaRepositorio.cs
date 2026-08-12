using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Mascota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Mascota
{
    public class MascotaRepositorio : IMascotaRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<MascotaResponse>> GetAll()
        {
            List<DbModel.DbColegio.Mascota> listaBd = await _db.Mascota.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<MascotaResponse?> GetById(int id)
        {
            DbModel.DbColegio.Mascota? dbres = await _db.Mascota.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<MascotaResponse?> Create(MascotaRequest request)
        {
            DbModel.DbColegio.Mascota newObject = new DbModel.DbColegio.Mascota
            {
                CategoriaMascota = request.CategoriaMascota,
                Raza = request.Raza,
                Edad = request.Edad,
                Nombre = request.Nombre,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };

            await _db.Mascota.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<MascotaResponse?> Update(int id, MascotaRequest request)
        {
            DbModel.DbColegio.Mascota? dbres = await _db.Mascota.FindAsync(id);
            if (dbres is null) return null;

            dbres.CategoriaMascota = request.CategoriaMascota;
            dbres.Raza = request.Raza;
            dbres.Edad = request.Edad;
            dbres.Nombre = request.Nombre;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;

            _db.Mascota.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(int id)
        {
            DbModel.DbColegio.Mascota? dbres = await _db.Mascota.FindAsync(id);
            if (dbres is null) return false;

            _db.Mascota.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static MascotaResponse MapToResponse(DbModel.DbColegio.Mascota x)
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
    }
}
