using MaratonandoApp.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class SerieLibrary
    {
        public int SerieLibraryId { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<SerieOnLibrary> SerieOnLibrary { get; set; }

    }
}
