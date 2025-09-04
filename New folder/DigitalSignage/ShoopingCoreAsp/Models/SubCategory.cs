using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class SubCategory
    {
        public int id { get; set; }
        public String name { get; set; }
        public String sub_name { get; set; }
        public String image { get; set; }
        public int status { get; set; }
        public int category_id { get; set; }

    }
}
