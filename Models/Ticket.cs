using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Reservations = new HashSet<Reservation>();
        }

        public uint Id { get; set; }
        public DateTime? IssuedDate { get; set; }
        public ushort SeatId { get; set; }
        public byte? DiscountId { get; set; }
        public ushort? EmployeeId { get; set; }
        public uint ScreeningId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
