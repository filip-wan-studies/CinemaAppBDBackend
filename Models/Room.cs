using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Room
    {
        public Room()
        {
            Screenings = new HashSet<Screening>();
            Seats = new HashSet<Seat>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public short SeatCount { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
