using TiendaServicios.API.Autor.Persistencia;
using Microsoft.EntityFrameworkCore;
using MediatR;
using TiendaServicios.API.Autor.Aplicacion;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


/*Configuraciones para arranque del servicio*/

builder.Services.AddDbContext<ContextoAutor>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("ConexionServicio"),
                         new MySqlServerVersion(new Version(8, 0, 34))));

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());


/*------------------------------------------*/

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

