using MySql.Data.MySqlClient;
using S03AN1.Modelos.EstadoCliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace S03AN1.Repositorio.EstadoCliente
{
    public class EstadoClienteRepositorio : IEstadoClienteRepositorio
    {
        private string cdnx = "Server=localhost;Port=3306;Database=2026_S03AN1;User=root;Password=root123;";


        public async Task<List<EstadoClienteResponse>> GetAll()
        {
            List<EstadoClienteResponse> lista = new List<EstadoClienteResponse>();

            using (var conn = new MySqlConnection(cdnx))
            {
                await conn.OpenAsync();

                string query = "SELECT * FROM dbo_estado_cliente";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new EstadoClienteResponse
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Codigo = reader["codigo"].ToString()!,
                                Descripcion = reader["descripcion"].ToString()!
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public Task<EstadoClienteResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EstadoClienteResponse> Create(EstadoClienteRequest request)
        {
            throw new NotImplementedException();
        }

  

        public Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
