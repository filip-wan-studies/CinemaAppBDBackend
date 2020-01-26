using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Room
    {
        public Room()
        {
            Screenseats = new HashSet<Screenseat>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public short SeatCount { get; set; }

        public virtual ICollection<Screenseat> Screenseats { get; set; }
    }
}
