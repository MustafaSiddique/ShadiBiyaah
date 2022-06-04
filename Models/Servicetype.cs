using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Servicetype
    {
        public Servicetype()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ServiceCategoryId { get; set; }

        public virtual Servicecategory? ServiceCategory { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
