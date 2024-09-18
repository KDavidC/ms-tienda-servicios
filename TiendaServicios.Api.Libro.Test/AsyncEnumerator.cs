using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.Libro.Test
{
    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public T Current => _enumerator.Current;

        public AsyncEnumerator(IEnumerator<T> enumerator) => _enumerator = enumerator ?? throw new ArgumentNullException();

        //Indicar que espere hasta que se complete la tarea
        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        //
        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(_enumerator.MoveNext());
        }
    }
}

