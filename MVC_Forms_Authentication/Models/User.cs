using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Forms_Authentication.Models {
    public class User {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}