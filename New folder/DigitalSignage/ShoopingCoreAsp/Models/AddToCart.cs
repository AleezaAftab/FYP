using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class AddToCart
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
        public string product_image { get; set; }
        public string session { get; set; }

    }
}
