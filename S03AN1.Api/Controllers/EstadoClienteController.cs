using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S03AN1.Modelos.EstadoCliente;

namespace S03AN1.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstadoClienteController : ControllerBase
{

    //nosotros vamos a construir end points basados en HTTP
    //GET POST PUT DELETE

    [HttpGet]
    public ActionResult<List<EstadoClienteResponse>> Get()
    {
        var estados = new List<EstadoClienteResponse>
        {
            new EstadoClienteResponse { Id = 1, Codigo = "ACT", Descripcion = "Activo" },
            new EstadoClienteResponse { Id = 2, Codigo = "INA", Descripcion = "Inactivo" },
            new EstadoClienteResponse { Id = 3, Codigo = "PEN", Descripcion = "Pendiente" }
        };
        return Ok(estados);
    }


    [HttpGet("banco/{codigoBanco}")]
    public ActionResult<List<EstadoClienteResponse>> Get(string codigoBanco)
    {
        var estados = new List<EstadoClienteResponse>
        {
            new EstadoClienteResponse { Id = 1, Codigo = "ACT", Descripcion = "Activo" },
            new EstadoClienteResponse { Id = 2, Codigo = "INA", Descripcion = "Inactivo" },
            new EstadoClienteResponse { Id = 3, Codigo = "PEN", Descripcion = "Pendiente" },
            new EstadoClienteResponse { Id = 4, Codigo = "xxx", Descripcion = codigoBanco }
        };
        return Ok(estados);
    }


    [HttpPost]
    public ActionResult<string> Post([FromBody] EstadoClienteRequest request)
    {
        //aqui vamos a recibir un objeto de tipo EstadoClienteRequest
        //y vamos a retornar un mensaje de exito
        return Ok("CREADO");
    }

    [HttpPut("{id}")]
    public ActionResult<string> Put(int id, [FromBody] EstadoClienteRequest request)
    {
        //aqui vamos a recibir un objeto de tipo EstadoClienteRequest
        //y vamos a retornar un mensaje de exito
        return Ok("ACTUALIZADO");
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
        //aqui vamos a recibir un id de tipo int
        //y vamos a retornar un mensaje de exito
        return Ok("ELIMINADO");
    }
}
