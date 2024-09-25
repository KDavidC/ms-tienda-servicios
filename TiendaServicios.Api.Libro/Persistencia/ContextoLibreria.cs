using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
	public class ContextoLibreria : DbContext
	{
		public ContextoLibreria() { }

		public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options){ }

        public DbSet<LibroMaterial> LibroMaterial  { get; set; }

		//Modelo de tipo entidad para utilizarlo especificamente en las pruebas unitarias
        //public virtual DbSet<LibroMaterial> LibroMaterial { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
                var configuracion = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
                string cadenaConexion = configuracion.GetConnectionString("CadenaLibreria");
                optionsBuilder.UseMySql(cadenaConexion, new MySqlServerVersion(new Version(8, 0, 34)));
           

        }
		protected override void OnModelCreating(ModelBuilder builderModel)
		{
			builderModel.Entity<LibroMaterial>().HasKey("LibreriaMaterialId");

			base.OnModelCreating(builderModel);
		}

	}
}

