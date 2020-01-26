using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Seat
    {
        public Seat()
        {
            Screenseats = new HashSet<Screenseat>();
        }

        public ushort Id { get; set; }
        public sbyte RowNumber { get; set; }
        public sbyte SeatNumber { get; set; }
        public byte? RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Screenseat> Screenseats { get; set; }
    }
}
