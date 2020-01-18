using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int Rowing { get; set; }
        public int SeatNumber { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
