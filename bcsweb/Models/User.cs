using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bcsweb.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }
        public string Wharfcode { get; set; }
    }
}