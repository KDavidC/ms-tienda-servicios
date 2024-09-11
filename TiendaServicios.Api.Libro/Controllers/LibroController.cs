using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AgregaLibro([FromBody] Nuevo.Ejecuta data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult <List<LibroMaterialDTO>>> GetLibros()
        {
            return await _mediator.Send(new Consulta.ListaLibro());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<LibroMaterialDTO>> LibroFiltro(Guid Id)
        {
            return await _mediator.Send(new ConsultaFiltroLib.LibroUnico { AutorLibro = Id });
        }
    }
}

