using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Packagedetail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public int Price { get; set; }
        public string Image { get; set; } = null!;
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
    }
}
