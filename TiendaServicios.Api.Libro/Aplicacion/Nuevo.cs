using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
	public class Nuevo
	{
		public Nuevo()
		{

		}
		public class Ejecuta : IRequest
		{
			[Required]
			public string Titulo { get; set; }

			[Required]
			public DateTime FechaPublicacion { get; set; }

			[Required]
			public Guid AutorLibro { get; set; }

		}

        public class Manejador : IRequestHandler<Ejecuta>
        {
			private readonly ContextoLibreria _contextLibro;

			public Manejador(ContextoLibreria contextoLibreria)
			{
				_contextLibro = contextoLibreria;
			}

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
				string mensajeError = string.Empty;
				try
				{
					var objLibro = new LibroMaterial()
					{
						Titulo = request.Titulo,
						FechaPublicacion = request.FechaPublicacion,
						AutorLibro = request.AutorLibro
					};

					_contextLibro.LibroMaterial.Add(objLibro);
					var respuesta = await _contextLibro.SaveChangesAsync();
					if (respuesta > 0)
					{
						return Unit.Value;
					}
				}
				catch (Exception ex)
				{
					mensajeError = ex.Message;
                }
                throw new NotImplementedException(mensajeError);
            }
        }
    }
}

