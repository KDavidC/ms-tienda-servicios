using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Persistencia;
using MediatR;
using TiendaServicios.Api.Libro.Aplicacion;
var builder = WebApplication.CreateBuilder(args);

/*********Configuraciones del EndPoint********/

builder.Services.AddDbContext<ContextoLibreria>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString(""),
    new MySqlServerVersion(new Version(8, 0, 34))));

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

/************************************************/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

