using S03AN1.Modelos.EstadoCliente;
using S03AN1.Repositorio.EstadoCliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03AN1.Negocio.EstadoCliente
{
    public class EstadoClienteNegocio : IEstadoClienteNegocio
    {
        #region variables y constructor
        private readonly IEstadoClienteRepositorio _estadoClienteRepositorio;

        public EstadoClienteNegocio(IEstadoClienteRepositorio estadoClienteRepositorio)
        {
            _estadoClienteRepositorio = estadoClienteRepositorio;
        }

        #endregion

        public async Task<List<EstadoClienteResponse>> GetAll()
        {
            List<EstadoClienteResponse>  estados = await _estadoClienteRepositorio.GetAll();
            return estados;

        }

        public async Task<EstadoClienteResponse> GetById(int id)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.GetById(id);
            return response;
        }


        public async Task<EstadoClienteResponse> Create(EstadoClienteRequest request)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.Create(request);
            return response;
        }

        public async Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.Update(id, request);
            return response;
        }

        public async Task<bool> Delete(int id)
        {
            bool result = await _estadoClienteRepositorio.Delete(id);
            return result;
        }
    }
}