using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public bool FlAssistido { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public DateTime DataAssistido { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public int NotaFilme { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public bool FlFavorito { get; set; }
    }
}
