using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Tickets
    {
        public uint IdTicket { get; set; }
        public sbyte SeatNumber { get; set; }
        public byte IdRoom { get; set; }
        public byte IdPrice { get; set; }
        public byte IdDiscount { get; set; }
        public ushort IdEmployee { get; set; }
        public uint IdScreening { get; set; }

        public virtual Discounts IdDiscountNavigation { get; set; }
        public virtual Employees IdEmployeeNavigation { get; set; }
        public virtual Prices IdPriceNavigation { get; set; }
        public virtual Rooms IdRoomNavigation { get; set; }
        public virtual Screenings IdScreeningNavigation { get; set; }
    }
}
