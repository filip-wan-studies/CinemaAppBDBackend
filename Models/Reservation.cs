using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Reservation
    {
        public uint Id { get; set; }
        public uint TicketId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public uint? ClientId { get; set; }
        public string Email { get; set; }

        public virtual Client Client { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
