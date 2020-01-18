using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int? ClientId { get; set; }
        public string Email { get; set; }

        public virtual Client Client { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
