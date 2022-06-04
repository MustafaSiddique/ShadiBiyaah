using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string? Review { get; set; }
        public int Rating1 { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
    }
}
