using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Tickets = new HashSet<Ticket>();
        }

        public uint IdScreening { get; set; }
        public uint IdFilm { get; set; }
        public byte IdPrice { get; set; }
        public DateTime DateScreening { get; set; }

        public virtual Film FilmNavigation { get; set; }
        public virtual Price PriceNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
