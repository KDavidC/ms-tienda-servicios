using System;
namespace TiendaServicios.API.Autor.Aplicacion
{
    //Fuciona para modelar la data que se envia al cliente
	public class AutoDto
	{

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}

