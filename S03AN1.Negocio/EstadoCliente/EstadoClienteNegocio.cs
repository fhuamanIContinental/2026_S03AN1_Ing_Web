using S03AN1.Modelos.EstadoCliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03AN1.Negocio.EstadoCliente
{
    public class EstadoClienteNegocio : IEstadoClienteNegocio
    {
        public async Task<List<EstadoClienteResponse>> GetAll()
        {
            var estados = new List<EstadoClienteResponse>
            {
                new EstadoClienteResponse { Id = 1, Codigo = "ACT", Descripcion = "Activo" },
                new EstadoClienteResponse { Id = 2, Codigo = "INA", Descripcion = "Inactivo" },
                new EstadoClienteResponse { Id = 3, Codigo = "PEN", Descripcion = "Pendiente" }
            };

            return await Task.FromResult(estados);

        }

        public Task<EstadoClienteResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<EstadoClienteResponse> Create(EstadoClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    
        

        public Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
