using System;
namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
	public class CarritoDTO
	{
		public int? CarritoId { get; set; }

		public DateTime? fechaCreacionSesion { get; set; }

		public List<CarritoDetalleDTO> lstCarritoDetalle { get; set; }
	}
}

