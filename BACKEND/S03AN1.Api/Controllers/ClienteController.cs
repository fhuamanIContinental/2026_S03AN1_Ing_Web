using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.Cliente;
using S03AN1.Modelos.General;
using S03AN1.Negocio.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con los clientes.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    #region variables y constructor
    private readonly IClienteNegocio _clienteNegocio;

    /// <summary>
    /// Constructor del controlador de Cliente.
    /// </summary>
    /// <param name="clienteNegocio">Inyección del servicio de negocio de cliente.</param>
    public ClienteController(IClienteNegocio clienteNegocio)
    {
        _clienteNegocio = clienteNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todos los clientes disponibles.
    /// </summary>
    /// <returns>Lista de todos los clientes.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<ClienteResponse>>>> Get()
    {
        GeneralResponse<List<ClienteResponse>> response = await _clienteNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene un cliente por su ID.
    /// </summary>
    /// <param name="id">ID del cliente a buscar.</param>
    /// <returns>El cliente encontrado o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<ClienteResponse?>>> GetById(int id)
    {
        GeneralResponse<ClienteResponse?> response = await _clienteNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo cliente.
    /// </summary>
    /// <param name="request">Datos del cliente a crear.</param>
    /// <returns>El cliente creado.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<ClienteResponse?>>> Post([FromBody] ClienteRequest request)
    {
        GeneralResponse<ClienteResponse?> resultado = await _clienteNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un cliente existente.
    /// </summary>
    /// <param name="id">ID del cliente a actualizar.</param>
    /// <param name="request">Datos del cliente a actualizar.</param>
    /// <returns>El cliente actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<ClienteResponse?>>> Put(int id, [FromBody] ClienteRequest request)
    {
        GeneralResponse<ClienteResponse?> resultado = await _clienteNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un cliente por su ID.
    /// </summary>
    /// <param name="id">ID del cliente a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _clienteNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
