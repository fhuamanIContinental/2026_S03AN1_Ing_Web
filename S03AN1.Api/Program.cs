using Microsoft.OpenApi.Models;
using S03AN1.Negocio.EstadoCliente;
using S03AN1.Repositorio.EstadoCliente;
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
    c.MapType<string>(() => new OpenApiSchema { Nullable = true });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


/*INYECCIÓN DE DEPENDENCIAS*/
builder.Services.AddScoped<IEstadoClienteNegocio, EstadoClienteNegocio>();
builder.Services.AddScoped<IEstadoClienteRepositorio, EstadoClienteRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //VAMOS A LEVANTAR LA INTERFACES GRAFICA DE SWAGGER
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
