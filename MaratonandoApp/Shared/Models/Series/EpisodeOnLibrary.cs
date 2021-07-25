using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class EpisodeOnLibrary
    {
        public int EpisodeLibraryId { get; set; }
        public EpisodeLibrary episodeLibrary { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public bool FlAssistido { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public DateTime DataAssistido { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public int NotaEpisodio { get; set; }
    }
}
