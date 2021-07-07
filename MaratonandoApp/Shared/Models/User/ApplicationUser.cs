using MaratonandoApp.Shared.Models.Film;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public FilmLibrary FilmLibrary { get; set; }

        public ICollection<FilmComment> FilmComments { get; set; }
    }
}
