using MaratonandoApp.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Film
{
    public class FilmComment
    {
        public int FilmCommentId { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
