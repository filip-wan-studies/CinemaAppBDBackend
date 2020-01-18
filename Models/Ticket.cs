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

        public int Id { get; set; }
        public DateTime? IssuedDate { get; set; }
        public int SeatId { get; set; }
        public int? DiscountId { get; set; }
        public int? EmployeeId { get; set; }
        public int ScreeningId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
