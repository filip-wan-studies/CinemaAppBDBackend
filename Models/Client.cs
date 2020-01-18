using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Secret { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
