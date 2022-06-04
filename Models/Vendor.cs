using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Bookings = new HashSet<Booking>();
            Services = new HashSet<Service>();
            Vendorcontactdetails = new HashSet<Vendorcontactdetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Vendorcontactdetail> Vendorcontactdetails { get; set; }
    }
}
