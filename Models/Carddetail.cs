using System;
using System.Collections.Generic;

namespace FypDb.Models
{
    public partial class Carddetail
    {
        public int Id { get; set; }
        public string NameOnCard { get; set; } = null!;
        public string CardNo { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateOnly ExpiryDate { get; set; }
    }
}
