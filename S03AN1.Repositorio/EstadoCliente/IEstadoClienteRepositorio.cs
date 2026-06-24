using S03AN1.Modelos.EstadoCliente;

namespace S03AN1.Repositorio.EstadoCliente
{
    public interface IEstadoClienteRepositorio
    {
        Task<List<EstadoClienteResponse>> GetAll();
        Task<EstadoClienteResponse> GetById(int id);
        Task<EstadoClienteResponse> Create(EstadoClienteRequest request);
        Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request);
        Task<bool> Delete(int id);
    }
}
