using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Tickets = new HashSet<Tickets>();
        }

        public ushort IdEmployee { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
