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

        public uint IdTicket { get; set; }
        public sbyte SeatNumber { get; set; }
        public byte IdRoom { get; set; }
        public byte IdPrice { get; set; }
        public byte IdDiscount { get; set; }
        public ushort IdEmployee { get; set; }
        public uint IdScreening { get; set; }

        public virtual Discount DiscountNavigation { get; set; }
        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Price PriceNavigation { get; set; }
        public virtual Room RoomNavigation { get; set; }
        public virtual Screening ScreeningNavigation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
