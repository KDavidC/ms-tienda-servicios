using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.API.Autor.Modelo;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Persistencia;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaServicios.API.Autor.Controllers
{

    public class ObtenerDatosServiceController : Controller
    {
        [HttpGet(Name = "ObtenDatosUsuario")]
        public IEnumerable<AutorLibro> ObtenerDatos()
        {
            List<AutorLibro> lstAutorLibroEF = new();
            using (ContextoAutor contexto = new ContextoAutor())
            {
                lstAutorLibroEF = contexto.AutorLibro.FromSqlRaw($"execute ObtenRegistros").ToList();
            }
            string dato1;
            foreach (var item in lstAutorLibroEF)
            {
                dato1 = item.Nombre;
            }
            return lstAutorLibroEF;
        }
    }
}

