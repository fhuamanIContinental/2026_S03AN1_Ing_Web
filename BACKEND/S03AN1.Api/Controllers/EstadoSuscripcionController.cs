using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.EstadoSuscripcion;
using S03AN1.Modelos.General;
using S03AN1.Negocio.EstadoSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar los estados de suscripción.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class EstadoSuscripcionController : ControllerBase
{
    #region variables y constructor
    private readonly IEstadoSuscripcionNegocio _estadoSuscripcionNegocio;

    /// <summary>
    /// Constructor del controlador de EstadoSuscripcion.
    /// </summary>
    /// <param name="estadoSuscripcionNegocio">Inyección del servicio de negocio de EstadoSuscripcion.</param>
    public EstadoSuscripcionController(IEstadoSuscripcionNegocio estadoSuscripcionNegocio)
    {
        _estadoSuscripcionNegocio = estadoSuscripcionNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todos los estados de suscripción.
    /// </summary>
    /// <returns>Lista de estados de suscripción.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<EstadoSuscripcionResponse>>>> Get()
    {
        GeneralResponse<List<EstadoSuscripcionResponse>> response = await _estadoSuscripcionNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene un estado de suscripción por su ID.
    /// </summary>
    /// <param name="id">ID del estado de suscripción a buscar.</param>
    /// <returns>El estado de suscripción encontrado o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<EstadoSuscripcionResponse?>>> GetById(int id)
    {
        GeneralResponse<EstadoSuscripcionResponse?> response = await _estadoSuscripcionNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo estado de suscripción.
    /// </summary>
    /// <param name="request">Datos del estado de suscripción a crear.</param>
    /// <returns>El estado de suscripción creado.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<EstadoSuscripcionResponse?>>> Post([FromBody] EstadoSuscripcionRequest request)
    {
        GeneralResponse<EstadoSuscripcionResponse?> resultado = await _estadoSuscripcionNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un estado de suscripción existente.
    /// </summary>
    /// <param name="id">ID del estado de suscripción a actualizar.</param>
    /// <param name="request">Datos del estado de suscripción a actualizar.</param>
    /// <returns>El estado de suscripción actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<EstadoSuscripcionResponse?>>> Put(int id, [FromBody] EstadoSuscripcionRequest request)
    {
        GeneralResponse<EstadoSuscripcionResponse?> resultado = await _estadoSuscripcionNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un estado de suscripción por su ID.
    /// </summary>
    /// <param name="id">ID del estado de suscripción a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _estadoSuscripcionNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
