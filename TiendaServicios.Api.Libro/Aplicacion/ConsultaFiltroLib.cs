using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
	public class ConsultaFiltroLib
	{
		public ConsultaFiltroLib()
		{
		}

		public class LibroUnico : IRequest<LibroMaterialDTO>
		{
			public Guid AutorLibro  { get; set; }
		}

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {
			private readonly ContextoLibreria _contextoLibreria;
			private readonly IMapper _mapper;

			public Manejador(ContextoLibreria contextoLibreria, IMapper mapper)
			{
				_contextoLibreria = contextoLibreria;
				_mapper = mapper;
			}

            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                
				var objLibreria = await _contextoLibreria.LibroMaterial.Where(x => x.AutorLibro == request.AutorLibro).FirstOrDefaultAsync();
				if(objLibreria == null)
				{
                    throw new Exception("No se encontro el autor");
                }

				var libreriaDto = _mapper.Map<LibroMaterial, LibroMaterialDTO>(objLibreria);
				return libreriaDto;
            }
        }
    }
}

