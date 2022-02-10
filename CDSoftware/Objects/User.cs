using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDSoftware.Objects
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int CreatedyBy { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsActive { get; set; }

    }
}
