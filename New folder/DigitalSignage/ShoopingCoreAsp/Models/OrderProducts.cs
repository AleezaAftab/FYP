using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class OrderProducts
    {
        public int id { get; set; }
        public string order_id { get; set; }
        public int product_id { get; set; }
        public string product_price { get; set; }
        public string quantity { get; set; }
        public string name { get; set; }
        public string image { get; set; }

    }
}
