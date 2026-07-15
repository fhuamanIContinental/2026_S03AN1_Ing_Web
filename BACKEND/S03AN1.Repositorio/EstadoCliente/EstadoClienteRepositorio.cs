using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using S03AN1.DbModel.DbColegio;
using S03AN1.Modelos.EstadoCliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03AN1.Repositorio.EstadoCliente
{
    public class EstadoClienteRepositorio : IEstadoClienteRepositorio
    {
        _dbContext _db = new _dbContext();

        public async Task<List<EstadoClienteResponse>> GetAll()
        {
            List<EstadoClienteResponse> lista = new List<EstadoClienteResponse>();

            List<DboEstadoCliente> listaBd = await _db.DboEstadoCliente.ToListAsync();

            lista = listaBd.Select(x => new EstadoClienteResponse
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion
            }).ToList();    
            return lista;
        }

        public async Task<EstadoClienteResponse?> GetById(int id)
        {
            DboEstadoCliente? dbres = await _db.DboEstadoCliente.FindAsync(id);

            EstadoClienteResponse response = new EstadoClienteResponse();

            if(dbres is null)
            {
                return null;
            }

            response.Descripcion = dbres.Descripcion;
            response.Codigo = dbres.Codigo;
            response.Id = dbres.Id;
            
            return response;
        }

        public async Task<EstadoClienteResponse?> Create(EstadoClienteRequest request)
        {
            DboEstadoCliente newObjec = new DboEstadoCliente();
            newObjec.Descripcion = request.Descripcion;
            newObjec.Codigo = request.Codigo;
            newObjec.Id = request.Id;
            await _db.DboEstadoCliente.AddAsync(newObjec);
            await _db.SaveChangesAsync();

            EstadoClienteResponse rpt = new EstadoClienteResponse();
            rpt.Descripcion = newObjec.Descripcion;
            rpt.Codigo = newObjec.Codigo;
            rpt.Id = newObjec.Id;
            return rpt;
        }

  

        public async Task<EstadoClienteResponse?> Update(int id, EstadoClienteRequest request)
        {

            DboEstadoCliente? dbres = await _db.DboEstadoCliente.FindAsync(id);

            if(dbres is null)
            {
                return null;
            }
            dbres.Descripcion = request.Descripcion;
            dbres.Codigo = request.Codigo;
            dbres.Id = request.Id;
            _db.DboEstadoCliente.Update(dbres);
            await _db.SaveChangesAsync();

            EstadoClienteResponse rpt = new EstadoClienteResponse();
            rpt.Descripcion = dbres.Descripcion;
            rpt.Codigo = dbres.Codigo;
            rpt.Id = dbres.Id;
            return rpt;
        }

        public async Task<bool> Delete(int id)
        {
            DboEstadoCliente? dbres = await _db.DboEstadoCliente.FindAsync(id);

            if (dbres is null)
            {
                return false;
            }

            _db.DboEstadoCliente.Remove(dbres);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}