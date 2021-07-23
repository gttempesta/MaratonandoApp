using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Film
{
    public class Film
    {
        public int FilmId { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

        [MaxLength(100)]
        public string Diretor { get; set; }

        public DateTime DataEstreia { get; set; }

        [MaxLength(500)]
        public string Sinopse { get; set; }

        [MaxLength(30)]
        public string Genero { get; set; }

        [MaxLength(300)]
        public string Poster { get; set; }

        public int Duracao { get; set; }

        [MaxLength(30)]
        public string Pais { get; set; }

        public ICollection<FilmsOnLibrary> FilmOnLibraries { get; set; }

        public ICollection<FilmComment> filmComments { get; set; }
    }
}
