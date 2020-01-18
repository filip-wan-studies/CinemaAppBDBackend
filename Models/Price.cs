using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Price
    {
        public Price()
        {
            Screenings = new HashSet<Screening>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ammount { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
