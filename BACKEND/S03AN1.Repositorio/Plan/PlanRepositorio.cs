using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.Plan
{
    public class PlanRepositorio : IPlanRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<PlanResponse>> GetAll()
        {
            List<DboPlan> listaBd = await _db.DboPlan.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<PlanResponse?> GetById(int id)
        {
            DboPlan? dbres = await _db.DboPlan.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<PlanResponse?> Create(PlanRequest request)
        {
            DboPlan newObject = new DboPlan
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

            await _db.DboPlan.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<PlanResponse?> Update(int id, PlanRequest request)
        {
            DboPlan? dbres = await _db.DboPlan.FindAsync(id);
            if (dbres is null) return null;

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

            _db.DboPlan.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(int id)
        {
            DboPlan? dbres = await _db.DboPlan.FindAsync(id);
            if (dbres is null) return false;

            _db.DboPlan.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static PlanResponse MapToResponse(DboPlan x)
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
    }
}
