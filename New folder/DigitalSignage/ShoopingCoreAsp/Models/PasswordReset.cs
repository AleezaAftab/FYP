using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class PasswordReset
    {
        public string old_password { get; set; }
        public string new_password { get; set; }
        public string confirm_password { get; set; }

    }
}
