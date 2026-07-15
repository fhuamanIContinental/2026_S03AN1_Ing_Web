using S03AN1.Modelos.EstadoCliente;
using S03AN1.Modelos.General;
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

        /// <summary>
        /// Obtiene todos los estados de cliente
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponse<List<EstadoClienteResponse>>> GetAll()
        {
            List<EstadoClienteResponse>  estados = await _estadoClienteRepositorio.GetAll();
            return new GeneralResponse<List<EstadoClienteResponse>>
            {
                Content = estados,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estados de cliente obtenidos correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<EstadoClienteResponse>> GetById(int id)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.GetById(id);
            return new GeneralResponse<EstadoClienteResponse>
            {
                Content = response,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estado de cliente obtenido correctamente",
                ShowAlert = false
            };
        }


        public async Task<GeneralResponse<EstadoClienteResponse>> Create(EstadoClienteRequest request)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.Create(request);
            return new GeneralResponse<EstadoClienteResponse>
            {
                Content = response,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estado de cliente creado correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<EstadoClienteResponse>> Update(int id, EstadoClienteRequest request)
        {
            EstadoClienteResponse response = await _estadoClienteRepositorio.Update(id, request);
            return new GeneralResponse<EstadoClienteResponse>
            {
                Content = response,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estado de cliente actualizado correctamente",
                ShowAlert = false
            };
        }

        public async Task<GeneralResponse<bool>> Delete(int id)
        {
            bool result = await _estadoClienteRepositorio.Delete(id);
            return new GeneralResponse<bool>
            {
                Content = result,
                Success = true,
                TextMessage = "Operación exitosa",
                TitleMessage = "Estado de cliente eliminado correctamente",
                ShowAlert = false
            };
        }
    }
}