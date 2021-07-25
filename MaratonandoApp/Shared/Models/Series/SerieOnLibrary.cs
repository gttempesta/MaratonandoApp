using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class SerieOnLibrary
    {
        public int SerieOnLibraryId { get; set; }

        public int SerieLibraryId { get; set; }
        public SerieLibrary SerieLibrary { get; set; }

        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public int SeriesStatus { get; set; }

        public EpisodeLibrary episodeLibrary { get; set; }
    }
}
