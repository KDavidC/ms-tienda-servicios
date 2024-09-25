using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Modelo;
using TiendaServicios.API.Autor.Persistencia;

namespace TiendaServicios.API.Autor.Aplicacion
{
	public class Consulta
	{
		public class ListaAutor : IRequest<List<AutoDto>>{ }

        public class Manejador : IRequestHandler<ListaAutor, List<AutoDto>>
        {
            private readonly ContextoAutor _contextoAutor;

            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contextoAutor, IMapper mapper)
            {
                _contextoAutor = contextoAutor;

                _mapper = mapper;
            }

            public async Task<List<AutoDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                try
                {
                    var ListaAutores = await _contextoAutor.AutorLibro.ToListAsync();
                    var autoresDto = _mapper.Map<List<AutorLibro>, List<AutoDto>>(ListaAutores); 



                    return autoresDto;
                }
                catch(Exception ex)
               {

                }
                throw new NotImplementedException();
            }
        }

    }
}

