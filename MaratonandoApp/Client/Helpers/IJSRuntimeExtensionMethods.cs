using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<DadosDbLocal> ObterEpisodiosPraSincronizar(this IJSRuntime js)
        {
            return await js.InvokeAsync<DadosDbLocal>("ObterEpisodiosPraSincronizar");
        }

        public static async ValueTask ApagarDbBrowser(this IJSRuntime js, string tabela, int id)
        {
            await js.InvokeVoidAsync("apagarDado", tabela, id);
        }

        public static async ValueTask GuardarEpisodioParaMarcar(this IJSRuntime js, int epid)
        {
            await js.InvokeVoidAsync("GuardarEpisodioParaMarcar", epid);
        }

        public static async ValueTask<int> AtualizarSincronacoesEmEspera(this IJSRuntime js)
        {
            return await js.InvokeAsync<int>("AtualizarSincronacoesEmEspera");
        }
    }
}
