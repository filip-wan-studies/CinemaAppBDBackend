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

        public int Id { get; set; }
        public int FilmId { get; set; }
        public int PriceId { get; set; }
        public DateTime ScreeningDate { get; set; }
        public int RoomId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Price Price { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
