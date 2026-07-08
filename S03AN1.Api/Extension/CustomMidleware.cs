using S03AN1.Modelos.General;
using System.Text.Json;

namespace S03AN1.Api.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomMidleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public CustomMidleware(RequestDelegate next)
        {
            _next = next;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            //HTTP => PODEMOS ENVIAR HEADER PARAMS?
            //vamos a obtener el header code-aplication

            string? codigoAplicaion = context.Request.Headers["code-application"];

            if (string.IsNullOrEmpty(codigoAplicaion))
            {
                //vamos a retornar una respuesta con general response
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new GeneralResponse
                {
                    ShowAlert = true,
                    Success = false,
                    TextMessage = "ERROR MIDLEWARE",
                    TitleMessage = "NO SE ENVIO ALGUNA VARIABLE"
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }



            // Lógica antes de ejecutar el siguiente middleware
            Console.WriteLine($"[CustomMidleware] Antes de la petición: {context.Request.Method} {context.Request.Path}");

            // Llamar al siguiente middleware en el pipeline o controller
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //PODER REGISTRAR ERRORES EN UN LOG, O ENVIAR A UN SISTEMA DE MONITOREO

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new GeneralResponse
                {
                    ShowAlert = true,
                    Success = false,
                    TextMessage = "ERROR PROCESO",
                    TitleMessage = "OCURRIO UN ERROR - CONSULTE CON EL DPTO DE SISTEMAS"
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }
        }
    }

    // Clase de extensión para registrar el middleware fácilmente
    public static class CustomMidlewareExtensions
    {
        public static IApplicationBuilder UseCustomMidleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMidleware>();
        }
    }
}
