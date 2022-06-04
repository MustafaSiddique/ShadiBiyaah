using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FypDb.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? BookingStatus { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName="Date")]
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int? PaymentStatus { get; set; }
        public int? ClientId { get; set; }
        public int? ServiceId { get; set; }
        public int? VendorId { get; set; }

        public virtual Bookingstatus? BookingStatusNavigation { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Paymentstatus? PaymentStatusNavigation { get; set; }
        public virtual Service? Service { get; set; }
        public virtual Vendor? Vendor { get; set; }
    }
}
