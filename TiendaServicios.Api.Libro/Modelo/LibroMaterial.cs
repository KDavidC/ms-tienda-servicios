using System;
namespace TiendaServicios.Api.Libro.Modelo
{
	public class LibroMaterial
	{
		public int LibreriaMaterialId { get; set; }

		public string? Titulo { get; set; }

		public DateTime? FechaPublicacion { get; set; }

		public Guid? AutorLibro { get; set; }
	}
}

