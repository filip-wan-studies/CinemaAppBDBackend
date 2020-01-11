using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Screenings
    {
        public Screenings()
        {
            Tickets = new HashSet<Tickets>();
        }

        public uint IdScreening { get; set; }
        public uint IdFilm { get; set; }
        public byte IdPrice { get; set; }
        public DateTime DateScreening { get; set; }

        public virtual Films IdFilmNavigation { get; set; }
        public virtual Prices IdPriceNavigation { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
