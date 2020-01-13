using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Reservation
    {
        public uint IdReservation { get; set; }
        public uint IdTicket { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime DateSubmission { get; set; }
        public uint? IdClient { get; set; }
        public string Email { get; set; }

        public virtual Client ClientNavigation { get; set; }
        public virtual Ticket TicketNavigation { get; set; }
    }
}
