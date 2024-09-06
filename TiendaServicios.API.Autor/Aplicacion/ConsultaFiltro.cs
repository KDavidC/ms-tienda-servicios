using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Modelo;
using TiendaServicios.API.Autor.Persistencia;

namespace TiendaServicios.API.Autor.Aplicacion
{
	public class ConsultaFiltro
	{
		public class AutorUnico : IRequest<ConsultaFiltroDto>
		{
			public string AutorLibroGuid { get; set; }
		}

        public class Manejador : IRequestHandler<AutorUnico, ConsultaFiltroDto>
        {
            public readonly ContextoAutor _contextoAutor;

            public readonly IMapper _mapper;

            public Manejador(ContextoAutor contextoAutor, IMapper mapper)
            {
                _contextoAutor = contextoAutor;
                _mapper = mapper;
            }
            public async Task<ConsultaFiltroDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
            
                try
                {
                    var autor =  await _contextoAutor.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorLibroGuid).FirstOrDefaultAsync();                    
                    if(autor == null )
                    {
                        throw new Exception("No se encontro el autor");
                    }
                    var autorDto = _mapper.Map<AutorLibro, ConsultaFiltroDto>(autor);

                    return autorDto;
                }
                catch(Exception ex)
                {

                }
                throw new NotImplementedException();
            }
        }
    }
}

