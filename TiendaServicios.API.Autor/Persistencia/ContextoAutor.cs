using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data;
using TiendaServicios.API.Autor.Modelo;

namespace TiendaServicios.API.Autor.Persistencia
{
	public class ContextoAutor:DbContext 
	{
		public ContextoAutor() {}
		public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options){ }

		/*Clases de tipo entidad*/
		public DbSet<AutorLibro> AutorLibro { get; set; }

		public DbSet<GradoAcademico> GradoAcademico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			if (!optionsBuilder.IsConfigured)
			{
				var configuracion = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
				string cadenaConexion = configuracion.GetSection("AppKeys")["CadenaServicio"];
				optionsBuilder.UseMySql(cadenaConexion, new MySqlServerVersion(new Version(8,0,34)));
			}
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<AutorLibro>().HasNoKey();
			builder.Entity<GradoAcademico>().HasNoKey();
			base.OnModelCreating(builder);
		}


    }
}
