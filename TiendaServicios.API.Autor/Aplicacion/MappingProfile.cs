using System;
using AutoMapper;
using TiendaServicios.API.Autor.Modelo;

namespace TiendaServicios.API.Autor.Aplicacion
{
	public class MappingProfile : Profile
	{
		
		public MappingProfile()
		{
            /*CreareMap funciona para indicar que modelo se va a mapear
			con el modelo DTO*/
            // CreateMap< ModeloOrigen , ModeloDestino>
            CreateMap<AutorLibro, AutoDto>();

			#region Mapeo para unico autor
            CreateMap<AutorLibro, ConsultaFiltroDto>();
            #endregion
        }




    }
}

