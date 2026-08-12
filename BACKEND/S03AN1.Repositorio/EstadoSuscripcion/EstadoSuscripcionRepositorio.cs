using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.EstadoSuscripcion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.EstadoSuscripcion
{
    public class EstadoSuscripcionRepositorio : IEstadoSuscripcionRepositorio
    {
        private readonly _dbContext _db = new _dbContext();

        public async Task<List<EstadoSuscripcionResponse>> GetAll()
        {
            List<DboEstadoSuscripcion> listaBd = await _db.DboEstadoSuscripcion.ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public async Task<EstadoSuscripcionResponse?> GetById(int id)
        {
            DboEstadoSuscripcion? dbres = await _db.DboEstadoSuscripcion.FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public async Task<EstadoSuscripcionResponse?> Create(EstadoSuscripcionRequest request)
        {
            DboEstadoSuscripcion newObject = new DboEstadoSuscripcion
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Descripcion = request.Descripcion
            };

            await _db.DboEstadoSuscripcion.AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public async Task<EstadoSuscripcionResponse?> Update(int id, EstadoSuscripcionRequest request)
        {
            DboEstadoSuscripcion? dbres = await _db.DboEstadoSuscripcion.FindAsync(id);
            if (dbres is null) return null;

            dbres.Codigo = request.Codigo;
            dbres.Descripcion = request.Descripcion;

            _db.DboEstadoSuscripcion.Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public async Task<bool> Delete(int id)
        {
            DboEstadoSuscripcion? dbres = await _db.DboEstadoSuscripcion.FindAsync(id);
            if (dbres is null) return false;

            _db.DboEstadoSuscripcion.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }

        private static EstadoSuscripcionResponse MapToResponse(DboEstadoSuscripcion x)
        {
            return new EstadoSuscripcionResponse
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion
            };
        }
    }
}
