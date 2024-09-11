using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
	public class Consulta
	{

		public class ListaLibro : IRequest <List<LibroMaterialDTO>>{ }

        public class Manejador : IRequestHandler<ListaLibro, List<LibroMaterialDTO>>
        {
            private readonly ContextoLibreria _contexto;

            private readonly IMapper _mapper;

            public  Manejador( ContextoLibreria contextoLibreria, IMapper mapper)
            {
                _contexto = contextoLibreria;
                _mapper = mapper;
            }

            public async Task<List<LibroMaterialDTO>> Handle(ListaLibro request, CancellationToken cancellationToken)
            {
                try
                {
                    var lstLibros = await _contexto.LibroMaterial.ToListAsync();
                    
                    var librosDto = _mapper.Map<List<LibroMaterial>, List<LibroMaterialDTO>>(lstLibros);
                    if (librosDto.Count > 0)
                    {
                        return librosDto;
                    }
                   
                }
                catch (Exception ex)
                {

                }
               

               

                throw new NotImplementedException("No existen libros con esos datos");
            }
        }

    }
}

