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

        public uint Id { get; set; }
        public string Title { get; set; }
        public ushort GenreId { get; set; }
        public string ImdbId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
