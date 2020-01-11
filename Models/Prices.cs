using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Prices
    {
        public Prices()
        {
            Screenings = new HashSet<Screenings>();
            Tickets = new HashSet<Tickets>();
        }

        public byte IdPrice { get; set; }
        public string Name { get; set; }
        public sbyte Ammount { get; set; }

        public virtual ICollection<Screenings> Screenings { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
