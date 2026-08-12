using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.General;
using S03AN1.Modelos.Mascota;
using S03AN1.Negocio.Mascota;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las mascotas.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MascotaController : ControllerBase
{
    #region variables y constructor
    private readonly IMascotaNegocio _mascotaNegocio;

    /// <summary>
    /// Constructor del controlador de Mascota.
    /// </summary>
    /// <param name="mascotaNegocio">Inyección del servicio de negocio de Mascota.</param>
    public MascotaController(IMascotaNegocio mascotaNegocio)
    {
        _mascotaNegocio = mascotaNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todas las mascotas.
    /// </summary>
    /// <returns>Lista de mascotas.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<MascotaResponse>>>> Get()
    {
        GeneralResponse<List<MascotaResponse>> response = await _mascotaNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene una mascota por su ID.
    /// </summary>
    /// <param name="id">ID de la mascota a buscar.</param>
    /// <returns>La mascota encontrada o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<MascotaResponse?>>> GetById(int id)
    {
        GeneralResponse<MascotaResponse?> response = await _mascotaNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea una nueva mascota.
    /// </summary>
    /// <param name="request">Datos de la mascota a crear.</param>
    /// <returns>La mascota creada.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<MascotaResponse?>>> Post([FromBody] MascotaRequest request)
    {
        GeneralResponse<MascotaResponse?> resultado = await _mascotaNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza una mascota existente.
    /// </summary>
    /// <param name="id">ID de la mascota a actualizar.</param>
    /// <param name="request">Datos de la mascota a actualizar.</param>
    /// <returns>La mascota actualizada.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<MascotaResponse?>>> Put(int id, [FromBody] MascotaRequest request)
    {
        GeneralResponse<MascotaResponse?> resultado = await _mascotaNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina una mascota por su ID.
    /// </summary>
    /// <param name="id">ID de la mascota a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _mascotaNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
