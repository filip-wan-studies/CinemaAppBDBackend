using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Film
    {
        public Film()
        {
            Screenings = new HashSet<Screening>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string ImdbId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
