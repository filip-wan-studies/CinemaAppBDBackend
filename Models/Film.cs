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

        public uint IdFilm { get; set; }
        public string Title { get; set; }
        public ushort IdGenre { get; set; }

        public virtual Genre GenreNavigation { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
