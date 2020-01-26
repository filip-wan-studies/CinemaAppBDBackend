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

        public ushort Id { get; set; }
        public bool IsReserved { get; set; }
        public sbyte RowNumber { get; set; }
        public sbyte SeatNumber { get; set; }
        public uint? ScreenSeatId { get; set; }

        public virtual Screenseat ScreenSeat { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
