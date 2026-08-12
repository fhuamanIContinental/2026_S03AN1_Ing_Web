using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Persona
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<PersonaResponse>> GetAll()
        {
            List<DbModel.DbColegio.Persona> listaBd = await _db.Persona.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<PersonaResponse?> GetById(int id)
        {
            DbModel.DbColegio.Persona? dbres = await _db.Persona.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<PersonaResponse?> Create(PersonaRequest request)
        {
            DbModel.DbColegio.Persona newObject = new DbModel.DbColegio.Persona
            {
                TipoDocumento = request.TipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };

            await _db.Persona.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<PersonaResponse?> Update(int id, PersonaRequest request)
        {
            DbModel.DbColegio.Persona? dbres = await _db.Persona.FindAsync(id);
            if (dbres is null) return null;

            dbres.TipoDocumento = request.TipoDocumento;
            dbres.NumeroDocumento = request.NumeroDocumento;
            dbres.Nombres = request.Nombres;
            dbres.ApellidoPaterno = request.ApellidoPaterno;
            dbres.ApellidoMaterno = request.ApellidoMaterno;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;

            _db.Persona.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(int id)
        {
            DbModel.DbColegio.Persona? dbres = await _db.Persona.FindAsync(id);
            if (dbres is null) return false;

            _db.Persona.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static PersonaResponse MapToResponse(DbModel.DbColegio.Persona x)
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
    }
}
