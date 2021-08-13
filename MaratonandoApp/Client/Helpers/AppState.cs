using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Client.Helpers
{
    public class AppState
    {
        public event Func<Task> OnAtualizarSincronizacoesEmEspera;
        public async Task NotificarAtualizarSincronizacoesEmEspera() =>
            await OnAtualizarSincronizacoesEmEspera?.Invoke();
    }
}
