using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Discounts
    {
        public Discounts()
        {
            Tickets = new HashSet<Tickets>();
        }

        public byte IdDiscount { get; set; }
        public string Name { get; set; }
        public short Ammount { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
