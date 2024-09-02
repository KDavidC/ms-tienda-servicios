using System;
namespace TiendaServicios.API.Autor.Modelo
{
	public class GradoAcademico
	{
		public GradoAcademico()
		{
		}
		public int GradoAcademicoId { get; set; }

		public string Nombre { get; set; }

		public string CentroAcademico { get; set; }

		public DateTime? FechaGradoAcademico { get; set; }

		public int AutorLibroID { get; set; }

        public AutorLibro AutorLibro { get; set; }

		public string GradoAcademicoGuid { get; set; }
	}
}

