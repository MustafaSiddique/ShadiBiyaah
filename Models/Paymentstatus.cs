using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Paymentstatus
    {
        public Paymentstatus()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
