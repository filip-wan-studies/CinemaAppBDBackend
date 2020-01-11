using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Films
    {
        public Films()
        {
            Screenings = new HashSet<Screenings>();
        }

        public uint IdFilm { get; set; }
        public string Title { get; set; }
        public ushort IdGenre { get; set; }

        public virtual Genres IdGenreNavigation { get; set; }
        public virtual ICollection<Screenings> Screenings { get; set; }
    }
}
