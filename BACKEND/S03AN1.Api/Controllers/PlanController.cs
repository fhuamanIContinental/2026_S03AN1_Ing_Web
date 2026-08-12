using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.General;
using S03AN1.Modelos.Plan;
using S03AN1.Negocio.Plan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S03AN1.Api.Controllers;

/// <summary>
/// Controlador para gestionar los planes del sistema.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    #region variables y constructor
    private readonly IPlanNegocio _planNegocio;

    /// <summary>
    /// Constructor del controlador de Plan.
    /// </summary>
    /// <param name="planNegocio">Inyección del servicio de negocio de Plan.</param>
    public PlanController(IPlanNegocio planNegocio)
    {
        _planNegocio = planNegocio;
    }
    #endregion

    /// <summary>
    /// Obtiene todos los planes disponibles.
    /// </summary>
    /// <returns>Lista de planes.</returns>
    [HttpGet]
    public async Task<ActionResult<GeneralResponse<List<PlanResponse>>>> Get()
    {
        GeneralResponse<List<PlanResponse>> response = await _planNegocio.GetAll();
        return Ok(response);
    }

    /// <summary>
    /// Obtiene un plan por su ID.
    /// </summary>
    /// <param name="id">ID del plan a buscar.</param>
    /// <returns>El plan encontrado o nulo.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneralResponse<PlanResponse?>>> GetById(int id)
    {
        GeneralResponse<PlanResponse?> response = await _planNegocio.GetById(id);
        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    /// <summary>
    /// Crea un nuevo plan.
    /// </summary>
    /// <param name="request">Datos del plan a crear.</param>
    /// <returns>El plan creado.</returns>
    [HttpPost]
    public async Task<ActionResult<GeneralResponse<PlanResponse?>>> Post([FromBody] PlanRequest request)
    {
        GeneralResponse<PlanResponse?> resultado = await _planNegocio.Create(request);
        return Ok(resultado);
    }

    /// <summary>
    /// Actualiza un plan existente.
    /// </summary>
    /// <param name="id">ID del plan a actualizar.</param>
    /// <param name="request">Datos del plan a actualizar.</param>
    /// <returns>El plan actualizado.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GeneralResponse<PlanResponse?>>> Put(int id, [FromBody] PlanRequest request)
    {
        GeneralResponse<PlanResponse?> resultado = await _planNegocio.Update(id, request);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }

    /// <summary>
    /// Elimina un plan por su ID.
    /// </summary>
    /// <param name="id">ID del plan a eliminar.</param>
    /// <returns>Indica si la eliminación fue exitosa.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GeneralResponse<bool>>> Delete(int id)
    {
        GeneralResponse<bool> resultado = await _planNegocio.Delete(id);
        if (!resultado.Success)
        {
            return NotFound(resultado);
        }
        return Ok(resultado);
    }
}
