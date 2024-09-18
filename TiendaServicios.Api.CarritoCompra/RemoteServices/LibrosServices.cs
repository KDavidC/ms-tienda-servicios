using System;
using System.Text.Json;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteServices
{
	public class LibrosServices : ILibrosServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibrosServices> _logger;

        public LibrosServices(IHttpClientFactory httpClient, ILogger<LibrosServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Metodo para invocar el endpoint de libro
        /// </summary>
        /// <param name="LibroId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<(bool resultado, LibroRemote libro, string mensajeError)> GetLibro(Guid LibroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
                //Colocar el endpoint que se va a utilizar
                //Utilizar la ruta establecida en el controlador 
                var response =  await cliente.GetAsync($"api/Libro/{LibroId}");
                //Validar que el consumo sea correcto
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStreamAsync();
                    //Funcionalidad para no tener problemas con las mayusculas y minusculas
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);

                    return (true, resultado, null);
                }
                return (false,null,response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false,null, ex.Message);
            }

            throw new NotImplementedException();
        }
        
    }
}

