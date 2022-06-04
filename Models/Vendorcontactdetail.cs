using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Vendorcontactdetail
    {
        public int Id { get; set; }
        public string PhoneNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FacebookId { get; set; }
        public string? InstagramId { get; set; }
        public int? VendorId { get; set; }

        public virtual Vendor? Vendor { get; set; }
    }
}
