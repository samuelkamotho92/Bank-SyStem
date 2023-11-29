using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Model
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public string role { get; set; }
    }
}
