using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Screenseats = new HashSet<Screenseat>();
            Tickets = new HashSet<Ticket>();
        }

        public uint Id { get; set; }
        public uint FilmId { get; set; }
        public byte PriceId { get; set; }
        public DateTime ScreeningDate { get; set; }

        public virtual Film Film { get; set; }
        public virtual Price Price { get; set; }
        public virtual ICollection<Screenseat> Screenseats { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
