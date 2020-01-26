using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Screenseat
    {
        public Screenseat()
        {
            Seats = new HashSet<Seat>();
        }

        public uint Id { get; set; }
        public byte? RoomId { get; set; }
        public uint? ScreeningsId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Screening Screenings { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
