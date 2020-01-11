using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Films = new HashSet<Films>();
        }

        public ushort IdGenre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Films> Films { get; set; }
    }
}
