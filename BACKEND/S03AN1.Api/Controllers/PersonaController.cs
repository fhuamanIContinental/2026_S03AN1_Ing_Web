using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.General;
using S03AN1.Modelos.Persona;
using S03AN1.Negocio.Persona;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar las personas.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    #region variables y constructor
    private readonly IPersonaNegocio _personaNegocio;

    /// <summary>
    /// Constructor del controlador de Persona.
    /// </summary>
    /// <param name="personaNegocio">Inyección del servicio de negocio de Persona.</param>
    public PersonaController(IPersonaNegocio personaNegocio)
    {
        _personaNegocio = personaNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todas las personas.
    /// </summary>
    /// <returns>Lista de personas.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<PersonaResponse>>>> Get()
    {
        GeneralResponse<List<PersonaResponse>> response = await _personaNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene el listado de personas de manera paginada.
    /// </summary>
    /// <param name="pageNumber">Número de página (por defecto 1).</param>
    /// <param name="pageSize">Tamaño de página (por defecto 10).</param>
    /// <returns>Objeto con elementos paginados y metadata.</returns>
    [HttpGet("paginated")]
    public async Task<ActionResult<GeneralResponse<PaginatedResponse<PersonaResponse>>>> GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        GeneralResponse<PaginatedResponse<PersonaResponse>> response = await _personaNegocio.GetPaginated(pageNumber, pageSize);
        return Ok(response);
    }

    /// <summary>
    /// Obtiene una persona por su ID.
    /// </summary>
    /// <param name="id">ID de la persona a buscar.</param>
    /// <returns>La persona encontrada o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<PersonaResponse?>>> GetById(int id)
    {
        GeneralResponse<PersonaResponse?> response = await _personaNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea una nueva persona.
    /// </summary>
    /// <param name="request">Datos de la persona a crear.</param>
    /// <returns>La persona creada.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<PersonaResponse?>>> Post([FromBody] PersonaRequest request)
    {
        GeneralResponse<PersonaResponse?> resultado = await _personaNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza una persona existente.
    /// </summary>
    /// <param name="id">ID de la persona a actualizar.</param>
    /// <param name="request">Datos de la persona a actualizar.</param>
    /// <returns>La persona actualizada.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<PersonaResponse?>>> Put(int id, [FromBody] PersonaRequest request)
    {
        GeneralResponse<PersonaResponse?> resultado = await _personaNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina una persona por su ID.
    /// </summary>
    /// <param name="id">ID de la persona a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _personaNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
