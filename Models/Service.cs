using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
            Favourites = new HashSet<Favourite>();
            Packagedetails = new HashSet<Packagedetail>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? VendorId { get; set; }
        public int? ServiceCategoryId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public int? CapacityMin { get; set; }
        public int? CapacityMax { get; set; }
        public string? About { get; set; }
        public string Services { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string AlbumId { get; set; } = null!;
        public int? ServiceTypeId { get; set; }
        public string? Status { get; set; }

        public virtual Servicecategory? ServiceCategory { get; set; }
        public virtual Servicetype? ServiceType { get; set; }
        public virtual Vendor? Vendor { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Packagedetail> Packagedetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
