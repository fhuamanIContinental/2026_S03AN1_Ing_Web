using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.ClienteSuscripcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.ClienteSuscripcion
{
    public class ClienteSuscripcionRepositorio : IClienteSuscripcionRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<ClienteSuscripcionResponse>> GetAll()
        {
            List<DboClienteSuscripcion> listaBd = await _db.DboClienteSuscripcion.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<ClienteSuscripcionResponse?> GetById(long id)
        {
            DboClienteSuscripcion? dbres = await _db.DboClienteSuscripcion.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<ClienteSuscripcionResponse?> Create(ClienteSuscripcionRequest request)
        {
            DboClienteSuscripcion newObject = new DboClienteSuscripcion
            {
                IdCliente = request.IdCliente,
                IdPlan = request.IdPlan,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Modalidad = request.Modalidad,
                MontoPactado = request.MontoPactado,
                IdEstado = request.IdEstado,
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = request.UsuarioCreacion
            };

            await _db.DboClienteSuscripcion.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<ClienteSuscripcionResponse?> Update(long id, ClienteSuscripcionRequest request)
        {
            DboClienteSuscripcion? dbres = await _db.DboClienteSuscripcion.FindAsync(id);
            if (dbres is null) return null;

            dbres.IdCliente = request.IdCliente;
            dbres.IdPlan = request.IdPlan;
            dbres.FechaInicio = request.FechaInicio;
            dbres.FechaFin = request.FechaFin;
            dbres.Modalidad = request.Modalidad;
            dbres.MontoPactado = request.MontoPactado;
            dbres.IdEstado = request.IdEstado;
            dbres.FechaModificacion = DateTime.UtcNow;
            dbres.UsuarioModificacion = request.UsuarioModificacion;

            _db.DboClienteSuscripcion.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(long id)
        {
            DboClienteSuscripcion? dbres = await _db.DboClienteSuscripcion.FindAsync(id);
            if (dbres is null) return false;

            _db.DboClienteSuscripcion.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static ClienteSuscripcionResponse MapToResponse(DboClienteSuscripcion x)
        {
            return new ClienteSuscripcionResponse
            {
                Id = x.Id,
                IdCliente = x.IdCliente,
                IdPlan = x.IdPlan,
                FechaInicio = x.FechaInicio,
                FechaFin = x.FechaFin,
                Modalidad = x.Modalidad,
                MontoPactado = x.MontoPactado,
                IdEstado = x.IdEstado,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                UsuarioCreacion = x.UsuarioCreacion,
                UsuarioModificacion = x.UsuarioModificacion
            };
        }
    }
}
