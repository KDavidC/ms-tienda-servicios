using System;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
	public interface ILibrosServices
	{
		Task<(bool resultado, LibroRemote libro, string mensajeError)> GetLibro(Guid LibroId);
	}

}

