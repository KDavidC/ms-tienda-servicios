using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Aplicacion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaServicios.Api.CarritoCompras.Controllers
{
    [Route("api/[controller]")]
    public class CarritoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarritoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet ("{id}")]

        public async Task<ActionResult<CarritoDTO>> GetCarritoDTO(int id)
        {
            return await _mediator.Send(new Consulta.Ejecuta { CarritoSesionId =  id });
        }

    }
}

