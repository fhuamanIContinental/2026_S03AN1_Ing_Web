using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.EstadoCliente;
using S03AN1.Negocio.EstadoCliente;

namespace S03AN1.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoClienteController : ControllerBase
{
    #region variables y constructor

    //declaración de variables
    private readonly IEstadoClienteNegocio _estadoClienteNegocio;

    //genereación del constructor
    public EstadoClienteController(IEstadoClienteNegocio estadoClienteNegocio)
    {
        _estadoClienteNegocio = estadoClienteNegocio;
    }

    #endregion



    //nosotros vamos a construir end points basados en HTTP
    //GET POST PUT DELETE

    [HttpGet]
    public async Task<ActionResult<List<EstadoClienteResponse>>> Get()
    {

        List<EstadoClienteResponse> estados = await _estadoClienteNegocio.GetAll();

        return Ok(estados);
    }


    [HttpPost]
    public async Task<ActionResult<EstadoClienteResponse>> Post([FromBody] EstadoClienteRequest request)
    {
        EstadoClienteResponse resultado = await _estadoClienteNegocio.Create(request);
        return Ok(resultado);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<EstadoClienteResponse>> Put(int id, [FromBody] EstadoClienteRequest request)
    {
        EstadoClienteResponse resultado = await _estadoClienteNegocio.Update(id, request);
        return Ok(resultado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        bool resultado = await _estadoClienteNegocio.Delete(id);

        return Ok(resultado);
    }
}
