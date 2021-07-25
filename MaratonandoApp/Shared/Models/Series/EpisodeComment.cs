using MaratonandoApp.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonandoApp.Shared.Models.Series
{
    public class EpisodeComment
    {
        public int EpisodeCommentId { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
