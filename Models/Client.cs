using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Favourites = new HashSet<Favourite>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
    }
}
