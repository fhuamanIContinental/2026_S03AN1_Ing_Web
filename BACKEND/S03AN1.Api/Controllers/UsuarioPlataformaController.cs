using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.General;
using S03AN1.Modelos.UsuarioPlataforma;
using S03AN1.Negocio.UsuarioPlataforma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar los usuarios de la plataforma.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsuarioPlataformaController : ControllerBase
{
    #region variables y constructor
    private readonly IUsuarioPlataformaNegocio _usuarioPlataformaNegocio;

    /// <summary>
    /// Constructor del controlador de UsuarioPlataforma.
    /// </summary>
    /// <param name="usuarioPlataformaNegocio">Inyección del servicio de negocio de UsuarioPlataforma.</param>
    public UsuarioPlataformaController(IUsuarioPlataformaNegocio usuarioPlataformaNegocio)
    {
        _usuarioPlataformaNegocio = usuarioPlataformaNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todos los usuarios de la plataforma.
    /// </summary>
    /// <returns>Lista de usuarios de plataforma.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<UsuarioPlataformaResponse>>>> Get()
    {
        GeneralResponse<List<UsuarioPlataformaResponse>> response = await _usuarioPlataformaNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene un usuario de plataforma por su ID.
    /// </summary>
    /// <param name="id">ID del usuario a buscar.</param>
    /// <returns>El usuario encontrado o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<UsuarioPlataformaResponse?>>> GetById(long id)
    {
        GeneralResponse<UsuarioPlataformaResponse?> response = await _usuarioPlataformaNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo usuario de plataforma.
    /// </summary>
    /// <param name="request">Datos del usuario a crear.</param>
    /// <returns>El usuario creado.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<UsuarioPlataformaResponse?>>> Post([FromBody] UsuarioPlataformaRequest request)
    {
        GeneralResponse<UsuarioPlataformaResponse?> resultado = await _usuarioPlataformaNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un usuario de plataforma existente.
    /// </summary>
    /// <param name="id">ID del usuario a actualizar.</param>
    /// <param name="request">Datos del usuario a actualizar.</param>
    /// <returns>El usuario actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<UsuarioPlataformaResponse?>>> Put(long id, [FromBody] UsuarioPlataformaRequest request)
    {
        GeneralResponse<UsuarioPlataformaResponse?> resultado = await _usuarioPlataformaNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un usuario de plataforma por su ID.
    /// </summary>
    /// <param name="id">ID del usuario a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(long id)
    {
        GeneralResponse<bool> resultado = await _usuarioPlataformaNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
