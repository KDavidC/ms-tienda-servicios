using System;
using AutoMapper;
using GenFu;
using Moq;
using Xunit;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicios.Api.Libro.Test
{
	public class LibrosServiceTest
	{
		//Sirve para obtener la data de tipo DTO
		private IEnumerable<LibroMaterial> ObtenerDataPrueba()
		{
            /*
				*El objeto A proviene de la libreria GenFu
				*AsArticleTitle sirve para modelar el titulo del libro
				*
			 */
            A.Configure<LibroMaterial>()
				.Fill(x => x.Titulo).AsArticleTitle()
				.Fill(x=> x.LibreriaMaterialId, () => { return Guid.NewGuid(); });

            /*
				* Se instancia ListOf, que proviene de la libreria GenFu, el cual
				* se indica que cree 30 datos
			 */
            var lista = A.ListOf<LibroMaterial>(30);

			lista[0].LibreriaMaterialId = Guid.Empty;

			return lista;
		}

		private Mock<ContextoLibreria> CrearContexto()
		{
			var dataPrueba = ObtenerDataPrueba().AsQueryable();

			var dbSet = new Mock<DbSet<LibroMaterial>>();
			/* 
				*Se indica que la clase LibroMaterial tiene que ser una clase de tipo entidad
				*Se debe dar un provider, una expression, un elemtType y un GetEnumerator
				*Ya que estas son las propiedades que debe tener una clase de EF
			 */
			dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<LibroMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

			dbSet.As<IAsyncEnumerable<LibroMaterial>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
			.Returns(new AsyncEnumerator<LibroMaterial>(dataPrueba.GetEnumerator()));

			var contexto = new Mock<ContextoLibreria>();
			contexto.Setup(x => x.LibroMaterial).Returns(dbSet.Object);
			return contexto;
		}


		[Fact]
		public async void GetLibros()
		{
			System.Diagnostics.Debugger.Launch();
			/*
				*Emular a la instancia de EF -ContextoLibreria
				*para emular las acciones y eventos de un objeto en un ambiente de unit test
				*se utiliza el objeto de tipo mock
			 
			 */
			var mockContexto = CrearContexto();

			/*
				* Emular al objeto Imapper
			 */
			var mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new MappingTest());
			});

			var mapper = mapConfig.CreateMapper();

			/*
				*Instanciar la clase manejador y pasarle como parametro
				* los objetos mock 
			 */
			Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mapper);

			Consulta.ListaLibro request = new Consulta.ListaLibro();

			var lista = await manejador.Handle(request,new System.Threading.CancellationToken());

			Assert.True(lista.Any());
		}
	}
}