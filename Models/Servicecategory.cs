using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Servicecategory
    {
        public Servicecategory()
        {
            Services = new HashSet<Service>();
            Servicetypes = new HashSet<Servicetype>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Servicetype> Servicetypes { get; set; }
    }
}
