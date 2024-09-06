using System;
using FluentValidation;
using MediatR;
using TiendaServicios.API.Autor.Modelo;
using TiendaServicios.API.Autor.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.API.Autor.Aplicacion
{
	public class Nuevo
	{
		public Nuevo()
		{
		}

		public class Ejecuta : IRequest
		{
            [Required]
            [MaxLength(100)]
            public string Nombre { get; set; }

            
            [MaxLength(100)]
            public string Apellido { get; set; }

			[Required]
			public DateTime FechaNacimiento { get; set; }
		}

		/*public class EjecutaValidacion : AbstractValidator<Ejecuta>
		{
			public EjecutaValidacion()
			{
				RuleFor(x => x.Nombre).NotEmpty();
				RuleFor(x => x.Apellido).NotEmpty();
				RuleFor(x => x.FechaNacimiento).NotEmpty();
			}
		}*/

        public class Manejador : IRequestHandler<Ejecuta>
        {
			public readonly ContextoAutor _contexto;

			public Manejador(ContextoAutor contexto)
			{
				_contexto = contexto;
			}

			//Task unit debe de devolver un valor 1 o 0 
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
				var autorLibro = new AutorLibro
				{
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };

				_contexto.AutorLibro.Add(autorLibro);
				/*Lo que hace SaveChanges confirma la transacción con mysql
				y devuelve 1 si es correcto o 0 si fue incorrecto
				 */
				var valor = await _contexto.SaveChangesAsync();
				if (valor > 0)
				{
					return Unit.Value;
				}
				throw new Exception("No se pudo guardar el autor del libro");
			}
        }
    }
}

