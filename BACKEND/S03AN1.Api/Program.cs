using Microsoft.OpenApi.Models;
using S03AN1.Api.Extension;
using S03AN1.Negocio.Cliente;
using S03AN1.Negocio.ClienteSuscripcion;
using S03AN1.Negocio.EstadoCliente;
using S03AN1.Negocio.EstadoSuscripcion;
using S03AN1.Negocio.Mascota;
using S03AN1.Negocio.Persona;
using S03AN1.Negocio.Plan;
using S03AN1.Negocio.UsuarioPlataforma;
using S03AN1.Repositorio.Cliente;
using S03AN1.Repositorio.ClienteSuscripcion;
using S03AN1.Repositorio.EstadoCliente;
using S03AN1.Repositorio.EstadoSuscripcion;
using S03AN1.Repositorio.Mascota;
using S03AN1.Repositorio.Persona;
using S03AN1.Repositorio.Plan;
using S03AN1.Repositorio.UsuarioPlataforma;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

/*  AQUI VAMOS A CONFIGURAR NUESTRO SWAGGER*/
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "mi primer swagger",
        Version = "v1",
        Description = "Documentación de nuestras APIs",
        Contact = new OpenApiContact
        {
            Name = "Franklin Huamán",
            Email = "fhuaman@continental.edu.pe",
            Url = new Uri("https://icontinental.edu.pe/"),
        },
    });
    // Agregar descripciones de tags/controladores
    c.TagActionsBy(api => new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] });
    c.DocInclusionPredicate((name, api) => true);

    c.MapType<string>(() => new OpenApiSchema { Nullable = true });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


/*INYECCIÓN DE DEPENDENCIAS*/
builder.Services.AddScoped<IEstadoClienteNegocio, EstadoClienteNegocio>();
builder.Services.AddScoped<IEstadoClienteRepositorio, EstadoClienteRepositorio>();

builder.Services.AddScoped<IClienteNegocio, ClienteNegocio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

builder.Services.AddScoped<IClienteSuscripcionNegocio, ClienteSuscripcionNegocio>();
builder.Services.AddScoped<IClienteSuscripcionRepositorio, ClienteSuscripcionRepositorio>();

builder.Services.AddScoped<IEstadoSuscripcionNegocio, EstadoSuscripcionNegocio>();
builder.Services.AddScoped<IEstadoSuscripcionRepositorio, EstadoSuscripcionRepositorio>();

builder.Services.AddScoped<IPlanNegocio, PlanNegocio>();
builder.Services.AddScoped<IPlanRepositorio, PlanRepositorio>();

builder.Services.AddScoped<IUsuarioPlataformaNegocio, UsuarioPlataformaNegocio>();
builder.Services.AddScoped<IUsuarioPlataformaRepositorio, UsuarioPlataformaRepositorio>();

builder.Services.AddScoped<IMascotaNegocio, MascotaNegocio>();
builder.Services.AddScoped<IMascotaRepositorio, MascotaRepositorio>();

builder.Services.AddScoped<IPersonaNegocio, PersonaNegocio>();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // AGREGAR MIDDLEWARE PARA SERVIR EL JSON DE SWAGGER
    app.UseSwagger();
    //VAMOS A LEVANTAR LA INTERFACES GRAFICA DE SWAGGER
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowAll");

//REGISTRANDO NUESTRO MIDLEWARE PERSONALIZADO EN EL PIPELINE DE LA APLICACIÓN
app.UseCustomMidleware();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
