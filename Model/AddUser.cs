using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_SyStem.Model
{
    public class AddUser
    {
       public string userName { get; set; }
        public string userPassword { get; set; }

        public string role = "user";
    }
}
