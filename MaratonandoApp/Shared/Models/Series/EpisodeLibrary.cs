using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class EpisodeLibrary
    {
        public int EpisodeLibraryId { get; set; }

        public int SerieOnLibraryId { get; set; }
        public SerieOnLibrary SerieOnLibrary { get; set; }

        public ICollection<EpisodeOnLibrary> EpisodeOnLibrary { get; set; }

    }
}
