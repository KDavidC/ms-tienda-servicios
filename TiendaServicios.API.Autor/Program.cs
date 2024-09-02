using TiendaServicios.API.Autor.Persistencia;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add DbContext to the services container
builder.Services.AddDbContext<ContextoAutor>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ConexionServicio"),
    new MySqlServerVersion(new Version(8, 0, 34))));

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

