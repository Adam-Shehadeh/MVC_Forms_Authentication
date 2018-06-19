using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Forms_Authentication.Models;


namespace MVC_Forms_Authentication.Classes {

    public static class UserRepository {
        public static User GetByUsernameAndPassword(User user) {
            return UserBase.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).First();
        }

        private static List<User> UserBase {
            get {
                return new List<User>(){
                    new User() {
                        UserID = 1,
                        Username = "MatchaMan69",
                        Password = "fuckme",
                        Name = "Bobert"
                    },
                    new User() {
                        UserID = 2,
                        Username = "Adrian100",
                        Password = "adrian",
                        Name = "Adriannnnnnn"
                    }
                };
            }
            set { }
        }

    }
}