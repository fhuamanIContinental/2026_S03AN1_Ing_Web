using S03AN1.Modelos.EstadoCliente;

namespace S03AN1.Negocio.EstadoCliente
{

    /*
        Una interfaz en C# es un contrato que define un conjunto de métodos, 
        propiedades, eventos o indexadores que una clase debe implementar. 
        Las interfaces permiten definir la estructura y el comportamiento 
        que una clase debe seguir sin proporcionar una implementación concreta.
     */


    public interface IEstadoClienteNegocio
    {
        Task<List<EstadoClienteResponse>> GetAll();
        Task<EstadoClienteResponse> GetById(int id);
        Task<EstadoClienteResponse> Create(EstadoClienteRequest request);
        Task<EstadoClienteResponse> Update(int id, EstadoClienteRequest request);
        Task<bool> Delete(int id);
    }
}
