using MaratonandoApp.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Film
{
    public class FilmComment
    {
        public int FilmCommentId { get; set; }

        [MaxLength(500)]
        public string ComentarioMsg { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Film Film { get; set; }
    }
}
