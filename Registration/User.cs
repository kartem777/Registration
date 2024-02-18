using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    internal class User
    {
        public string email {  get; set; }
        public string password { get; set; }
        public User(string _email, string _pass) { email = _email; password = _pass; }
    }
}
