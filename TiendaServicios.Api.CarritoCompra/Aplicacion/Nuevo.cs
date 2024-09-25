using System;
using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
	public class Nuevo
	{
		public class Ejecuta : IRequest
		{
			public DateTime fechaCreacionSesion { get; set; }

			public List<string> productoLista { get; set; }
		}

        public class Manejador : IRequestHandler<Ejecuta>
        {
			private readonly CarritoContexto _contexto;

			public Manejador(CarritoContexto contexto)
			{
				_contexto = contexto;
			}

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
				try
				{
                    var carritoSesion = new CarritoSesion
                    {
                        fechaCreacion = request.fechaCreacionSesion
                    };
                    _contexto.carritoSesion.Add(carritoSesion);
                    var value = await _contexto.SaveChangesAsync();
                    if (value == 0)
                    {
                        return Unit.Value;
                    }
                    //Recuperando el id que se acaba de insertar
                    int sesionId = carritoSesion.carritoSesionId;
                    foreach (var item in request.productoLista)
                    {       
                        //por cada elemento de la lista crear un nuevo objeto detalle
                        var detalleSesion = new CarritoSesionDetalle
                        {
                            fechaCreacion = DateTime.Now,
                            carritoSesionId = sesionId,
                            productoSeleccionado = item
                        };
                        //insertar en la tabla de detalle con los datos recopilados
                        _contexto.carritoSesionDetalle.Add(detalleSesion);
                    }
                    value = await _contexto.SaveChangesAsync();
                    if (value > 0)
                    {
                        return Unit.Value;
                    }

                }
                catch (Exception ex)
				{

				}
			
                throw new NotImplementedException("No se pudo insertar el detalle");
            }
        }
    }
}

