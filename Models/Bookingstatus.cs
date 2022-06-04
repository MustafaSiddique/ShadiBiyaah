using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Bookingstatus
    {
        public Bookingstatus()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
