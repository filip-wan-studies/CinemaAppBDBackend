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

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ammount { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
