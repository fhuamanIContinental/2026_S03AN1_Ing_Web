using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.EstadoCliente;
using S03AN1.Modelos.General;
using S03AN1.Negocio.EstadoCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con el estado del cliente.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EstadoClienteController : ControllerBase
{
    #region variables y constructor
    private readonly IEstadoClienteNegocio _estadoClienteNegocio;

    /// <summary>
    /// Constructor de la clase EstadoClienteController.
    /// </summary>
    /// <param name="estadoClienteNegocio">Inyección del servicio de negocio.</param>
    public EstadoClienteController(IEstadoClienteNegocio estadoClienteNegocio)
    {
        _estadoClienteNegocio = estadoClienteNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todos los estados de cliente disponibles.
    /// </summary>
    /// <returns>Lista de estados de cliente.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<EstadoClienteResponse>>>> Get()
    {
        GeneralResponse<List<EstadoClienteResponse>> response = await _estadoClienteNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene el listado de estados de cliente de manera paginada.
    /// </summary>
    /// <param name="pageNumber">Número de página (por defecto 1).</param>
    /// <param name="pageSize">Tamaño de página (por defecto 10).</param>
    /// <returns>Objeto con elementos paginados y metadata.</returns>
    [HttpGet("paginated")]
    public async Task<ActionResult<GeneralResponse<PaginatedResponse<EstadoClienteResponse>>>> GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        GeneralResponse<PaginatedResponse<EstadoClienteResponse>> response = await _estadoClienteNegocio.GetPaginated(pageNumber, pageSize);
        return Ok(response);
    }

    /// <summary>
    /// Obtiene un estado de cliente por su ID.
    /// </summary>
    /// <param name="id">ID del estado de cliente a buscar.</param>
    /// <returns>El estado de cliente encontrado o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<EstadoClienteResponse?>>> GetById(int id)
    {
        GeneralResponse<EstadoClienteResponse?> response = await _estadoClienteNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo estado de cliente.
    /// </summary>
    /// <param name="request">Datos del estado de cliente a crear.</param>
    /// <returns>El estado de cliente creado.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<EstadoClienteResponse?>>> Post([FromBody] EstadoClienteRequest request)
    {
        GeneralResponse<EstadoClienteResponse?> resultado = await _estadoClienteNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un estado de cliente existente.
    /// </summary>
    /// <param name="id">ID del estado de cliente a actualizar.</param>
    /// <param name="request">Datos del estado de cliente a actualizar.</param>
    /// <returns>El estado de cliente actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<EstadoClienteResponse?>>> Put(int id, [FromBody] EstadoClienteRequest request)
    {
        GeneralResponse<EstadoClienteResponse?> resultado = await _estadoClienteNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un estado de cliente por su ID.
    /// </summary>
    /// <param name="id">ID del estado de cliente a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _estadoClienteNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
