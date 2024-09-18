using System;
using AutoMapper;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Test
{
	public class MappingTest : Profile
	{
		public MappingTest()
		{
			// CreateMap< ModeloOrigen , ModeloDestino>
			CreateMap<LibroMaterial, LibroMaterialDTO>();
		}
	}
}

