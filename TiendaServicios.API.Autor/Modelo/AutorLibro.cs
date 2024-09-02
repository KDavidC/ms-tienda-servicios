using System;
namespace TiendaServicios.API.Autor.Modelo
{
	public class AutorLibro
	{
		public AutorLibro()
		{
		}
		public int AutorLibroID { get; set; }

		public string Nombre { get; set; }

		public string Apellido { get; set; }

		public DateTime? FechaNacimiento { get; set; }

		public ICollection<GradoAcademico> ListaGradoAcademico{ get; set; }

		public List<AutorLibro> LstGradoAcademico { get; set; }

		public string AutorLibroGuid { get; set; }

	}
}

