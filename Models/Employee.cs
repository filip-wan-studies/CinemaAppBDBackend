using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Tickets = new HashSet<Ticket>();
        }

        public ushort IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
