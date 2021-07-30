using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class Episode
    {
        public int EpisodeId { get; set; }

        public string titulo { get; set; }
        public int nroEpisode { get; set; }
        public int nroTemporada { get; set; }
        public string sinopse { get; set; }

        [ForeignKey("SerieId")]
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public ICollection<EpisodeComment> episodeComments { get; set; }
        public ICollection<EpisodeOnLibrary> EpisodeOnLibrary { get; set; }

    }
}
