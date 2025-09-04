using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class Orders
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string total_price { get; set; }
        public string total_items { get; set; }
        public string status { get; set; }
        //public DateTime OrderDate { get; set; }
        public DateTime order_date { get; set; }


    }
}
