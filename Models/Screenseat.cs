using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Screenseat
    {
        public Screenseat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public uint Id { get; set; }
        public bool IsReserved { get; set; }
        public ushort? SeatId { get; set; }
        public uint? ScreeningId { get; set; }

        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
