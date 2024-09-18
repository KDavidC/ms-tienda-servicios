using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
	public class Consulta
	{
		public class Ejecuta : IRequest<CarritoDTO>
		{
			public int CarritoSesionId { get; set; }
		}

        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {
            private readonly CarritoContexto _contexto;
            private readonly ILibrosServices _libroService;

            public Manejador(CarritoContexto contexto, ILibrosServices libroService)
            {
                _contexto = contexto;
                _libroService = libroService;
            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //obtener la sesión del carrito
                var carritoSesion = await _contexto.carritoSesion.FirstOrDefaultAsync(x => x.carritoSesionId == request.CarritoSesionId);
                //obtener el detalle de la sesión
                var carritoSesionDetalle = await _contexto.carritoSesionDetalle.Where(x=> x.carritoSesionId == request.CarritoSesionId).ToListAsync();

                List<CarritoDetalleDTO> lstDetalle = new();

                foreach(var libro in carritoSesionDetalle)
                {
                   var response = await _libroService.GetLibro(new Guid(libro.productoSeleccionado));
                    if (response.resultado)
                    {
                        //resultado del consumo del microservicios libros
                        var objetoLibro = response.libro;
                        var carritoDetalle = new CarritoDetalleDTO
                        {
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            TituloLibro = objetoLibro.Titulo,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        lstDetalle.Add(carritoDetalle);
                    }
                }
                var carritoSesionDto = new CarritoDTO
                {
                    CarritoId = carritoSesion.carritoSesionId,
                    fechaCreacionSesion = carritoSesion.fechaCreacion,
                    lstCarritoDetalle = lstDetalle
                };

                return carritoSesionDto;
            }
        }
    }
}

