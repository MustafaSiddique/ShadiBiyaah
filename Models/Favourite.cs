using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Favourite
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Service? Service { get; set; }
    }
}
