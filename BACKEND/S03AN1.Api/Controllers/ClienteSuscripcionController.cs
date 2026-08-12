using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.ClienteSuscripcion;
using S03AN1.Modelos.General;
using S03AN1.Negocio.ClienteSuscripcion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las suscripciones de los clientes.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClienteSuscripcionController : ControllerBase
{
    #region variables y constructor
    private readonly IClienteSuscripcionNegocio _clienteSuscripcionNegocio;

    /// <summary>
    /// Constructor del controlador de ClienteSuscripcion.
    /// </summary>
    /// <param name="clienteSuscripcionNegocio">Inyección del servicio de negocio de ClienteSuscripcion.</param>
    public ClienteSuscripcionController(IClienteSuscripcionNegocio clienteSuscripcionNegocio)
    {
        _clienteSuscripcionNegocio = clienteSuscripcionNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todas las suscripciones de clientes.
    /// </summary>
    /// <returns>Lista de suscripciones de clientes.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<ClienteSuscripcionResponse>>>> Get()
    {
        GeneralResponse<List<ClienteSuscripcionResponse>> response = await _clienteSuscripcionNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene una suscripción por su ID.
    /// </summary>
    /// <param name="id">ID de la suscripción a buscar.</param>
    /// <returns>La suscripción encontrada o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<ClienteSuscripcionResponse?>>> GetById(long id)
    {
        GeneralResponse<ClienteSuscripcionResponse?> response = await _clienteSuscripcionNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea una nueva suscripción de cliente.
    /// </summary>
    /// <param name="request">Datos de la suscripción a crear.</param>
    /// <returns>La suscripción creada.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<ClienteSuscripcionResponse?>>> Post([FromBody] ClienteSuscripcionRequest request)
    {
        GeneralResponse<ClienteSuscripcionResponse?> resultado = await _clienteSuscripcionNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza una suscripción de cliente existente.
    /// </summary>
    /// <param name="id">ID de la suscripción a actualizar.</param>
    /// <param name="request">Datos de la suscripción a actualizar.</param>
    /// <returns>La suscripción actualizada.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<ClienteSuscripcionResponse?>>> Put(long id, [FromBody] ClienteSuscripcionRequest request)
    {
        GeneralResponse<ClienteSuscripcionResponse?> resultado = await _clienteSuscripcionNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina una suscripción por su ID.
    /// </summary>
    /// <param name="id">ID de la suscripción a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(long id)
    {
        GeneralResponse<bool> resultado = await _clienteSuscripcionNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
