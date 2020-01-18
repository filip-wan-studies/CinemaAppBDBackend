using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Price
    {
        public Price()
        {
            Screenings = new HashSet<Screening>();
            Tickets = new HashSet<Ticket>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public sbyte Ammount { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
