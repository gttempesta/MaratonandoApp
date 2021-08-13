using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaratonandoApp.Client.Helpers
{
    public class DadoDbLocal
    {
            public int Id { get; set; }
            public int idep { get; set; }
    }

    public class DadosDbLocal
    {
        public List<DadoDbLocal> EpisodiosParaMarcar { get; set; } = new List<DadoDbLocal>();

        public int ObterEmEspera()
        {
            var resultado = 0;

            resultado += EpisodiosParaMarcar.Count;

            return resultado;
        }

    }
}
