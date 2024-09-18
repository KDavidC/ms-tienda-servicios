using System;
namespace TiendaServicios.Api.CarritoCompra.Modelo
{ 
	public class CarritoSesion
	{
		public int carritoSesionId { get; set; }

		public DateTime fechaCreacion { get; set; }

		public List<CarritoSesionDetalle> ListaDetalle { get; set; }
	}
}