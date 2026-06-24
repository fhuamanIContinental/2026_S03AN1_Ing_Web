using S03AN1.Negocio.EstadoCliente;
using S03AN1.Repositorio.EstadoCliente;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


/*INYECCIÓN DE DEPENDENCIAS*/
builder.Services.AddScoped<IEstadoClienteNegocio, EstadoClienteNegocio>();
builder.Services.AddScoped<IEstadoClienteRepositorio, EstadoClienteRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
