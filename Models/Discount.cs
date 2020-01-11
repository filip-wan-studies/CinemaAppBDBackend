using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Tickets = new HashSet<Ticket>();
        }

        public byte IdDiscount { get; set; }
        public string Name { get; set; }
        public short Ammount { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
