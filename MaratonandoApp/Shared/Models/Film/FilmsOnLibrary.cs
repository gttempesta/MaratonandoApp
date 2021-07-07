using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Film
{
    public class FilmsOnLibrary
    {
        public int FilmLibraryId { get; set; }
        public FilmLibrary FilmLibrary { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public bool FlAssistido { get; set; }

        public DateTime DataAssistido { get; set; }

        public int NotaFilme { get; set; }

        public bool FlFavorito { get; set; }
    }
}
