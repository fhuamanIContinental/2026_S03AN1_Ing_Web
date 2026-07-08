using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.EstadoCliente;
using S03AN1.Negocio.EstadoCliente;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con el estado del cliente.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EstadoClienteController : ControllerBase
{
    #region variables y constructor

    //declaración de variables
    private readonly IEstadoClienteNegocio _estadoClienteNegocio;

    /// <summary>
    /// Constructor de la clase EstadoClienteController.
    /// </summary>
    /// <param name="estadoClienteNegocio"></param>
    public EstadoClienteController(IEstadoClienteNegocio estadoClienteNegocio)
    {
        _estadoClienteNegocio = estadoClienteNegocio;
    }

    #endregion

    /// <summary>
    /// Obtiene todos los estados de cliente disponibles.
    /// </summary>
    /// <returns></returns>

    [HttpGet]
    public async Task<ActionResult<List<EstadoClienteResponse>>> Get()
    {
        List<EstadoClienteResponse> estados = await _estadoClienteNegocio.GetAll();
        return Ok(estados);
    }

    /// <summary>
    /// Crea un nuevo estado de cliente.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<EstadoClienteResponse>> Post([FromBody] EstadoClienteRequest request)
    {
        EstadoClienteResponse resultado = await _estadoClienteNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un estado de cliente existente.
    /// </summary>
    /// <param name="id">ID del estado de cliente a actualizar.</param>
    /// <param name="request">Datos del estado de cliente a actualizar.</param>
    /// <returns>El estado de cliente actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<EstadoClienteResponse>> Put(int id, [FromBody] EstadoClienteRequest request)
    {
        EstadoClienteResponse resultado = await _estadoClienteNegocio.Update(id, request);
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un estado de cliente por su ID.
    /// </summary>
    /// <param name="id">ID del estado de cliente a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        bool resultado = await _estadoClienteNegocio.Delete(id);

        return Ok(resultado);
    }
}
