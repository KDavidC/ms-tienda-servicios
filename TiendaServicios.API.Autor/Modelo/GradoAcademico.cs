using System;
namespace TiendaServicios.API.Autor.Modelo
{
	public class GradoAcademico
	{

		public int GradoAcademicoId { get; set; }

		public string? Nombre { get; set; }

		public string? CentroAcademico { get; set; }

		public DateTime? FechaGradoAcademico { get; set; }

		public int AutoriLibroId { get; set; }

		public AutorLibro autorLibro { get; set; }

		public string GradoAcademicoGuid { get; set; }
	}
}

