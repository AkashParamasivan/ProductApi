using System;
using System.Collections.Generic;

#nullable disable

namespace ProductApi.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
    }
}
