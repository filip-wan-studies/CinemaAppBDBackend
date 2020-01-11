using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }

        public ushort IdGenre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
