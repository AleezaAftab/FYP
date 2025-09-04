using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class Admin
    {
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public int status { get; set; }
        public String create_at { get; set; }
    }
}
