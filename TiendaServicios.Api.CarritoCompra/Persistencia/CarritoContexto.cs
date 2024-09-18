using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Modelo;

namespace TiendaServicios.Api.CarritoCompra.Persistencia
{
	public class CarritoContexto : DbContext
	{
		public CarritoContexto () { }

		public CarritoContexto(DbContextOptions <CarritoContexto> options) : base(options) { }

		public DbSet<CarritoSesion> carritoSesion { get; set; }

		public DbSet<CarritoSesionDetalle> carritoSesionDetalle { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            var configuracion = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
            string cadenaConexion = configuracion.GetConnectionString("ConexionCarrito");
            optionsBuilder.UseMySql(cadenaConexion, new MySqlServerVersion(new Version(8, 0, 34)));
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<CarritoSesion>().HasKey("carritoSesionId");
			builder.Entity<CarritoSesionDetalle>().HasKey("carritoSesionDetalleId");

		}
	}
}

