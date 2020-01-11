using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Tickets = new HashSet<Tickets>();
        }

        public byte IdRoom { get; set; }
        public string Name { get; set; }
        public short SeatCount { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
