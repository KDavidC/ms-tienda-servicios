using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Autor.Aplicacion;
using TiendaServicios.API.Autor.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaServicios.API.Autor.Controllers
{
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] Nuevo.Ejecuta data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return await _mediator.Send(data);
            }
            catch (Exception ex)
            {

            }
            return await _mediator.Send(data);
            
        }

        [HttpGet]
        public async Task<ActionResult<List<AutoDto>>> GetAutores()
        {
            List<AutoDto> lista = new();
            try
            {
                return await _mediator.Send(new Consulta.ListaAutor());
            }
            catch(Exception ex)
            {

            }
            return lista;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ConsultaFiltroDto>> GetAutorLibro(string Id)
        {
            return await _mediator.Send(new ConsultaFiltro.AutorUnico {AutorLibroGuid = Id });
        } 
    }
}

