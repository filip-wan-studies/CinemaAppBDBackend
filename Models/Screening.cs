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

        public uint Id { get; set; }
        public uint FilmId { get; set; }
        public byte PriceId { get; set; }
        public DateTime ScreeningDate { get; set; }
        public byte RoomId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Price Price { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
