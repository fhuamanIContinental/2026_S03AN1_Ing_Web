using Microsoft.EntityFrameworkCore;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S03AN1.Repositorio.General
{
    public abstract class GenericRepositorio<TEntity, TRequest, TResponse, TId> : IGenericRepositorio<TRequest, TResponse, TId>
        where TEntity : class
        where TResponse : class
    {
        protected readonly _dbContext _db = new _dbContext();

        protected abstract TResponse MapToResponse(TEntity entity);
        protected abstract TEntity MapToEntity(TRequest request);
        protected abstract void UpdateEntity(TEntity entity, TRequest request);

        public virtual async Task<List<TResponse>> GetAll()
        {
            List<TEntity> listaBd = await _db.Set<TEntity>().ToListAsync();
            return listaBd.Select(MapToResponse).ToList();
        }

        public virtual async Task<PaginatedResponse<TResponse>> GetPaginated(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            int totalRecords = await _db.Set<TEntity>().CountAsync();
            List<TEntity> itemsBd = await _db.Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<TResponse> items = itemsBd.Select(MapToResponse).ToList();

            return new PaginatedResponse<TResponse>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public virtual async Task<TResponse?> GetById(TId id)
        {
            TEntity? dbres = await _db.Set<TEntity>().FindAsync(id);
            if (dbres is null) return null;

            return MapToResponse(dbres);
        }

        public virtual async Task<TResponse?> Create(TRequest request)
        {
            TEntity newObject = MapToEntity(request);
            await _db.Set<TEntity>().AddAsync(newObject);
            await _db.SaveChangesAsync();

            return MapToResponse(newObject);
        }

        public virtual async Task<TResponse?> Update(TId id, TRequest request)
        {
            TEntity? dbres = await _db.Set<TEntity>().FindAsync(id);
            if (dbres is null) return null;

            UpdateEntity(dbres, request);
            _db.Set<TEntity>().Update(dbres);
            await _db.SaveChangesAsync();

            return MapToResponse(dbres);
        }

        public virtual async Task<bool> Delete(TId id)
        {
            TEntity? dbres = await _db.Set<TEntity>().FindAsync(id);
            if (dbres is null) return false;

            _db.Set<TEntity>().Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
