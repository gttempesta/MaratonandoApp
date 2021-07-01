using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Server.Models
{
    public class FilmLibrary
    {
        public int FilmLibraryId { get; set; }

        [MaxLength(450)]
        public string  UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
