using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models;

namespace Teamwork.Client.Core
{
    class AuthenticationManager
    {
        private static User currentUser;

        public static void Athorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(ErrorMessages.LoginFirst);
            }
        }

        public static void Login(User user)
        {
            if (IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            currentUser = user;
        }

        public static void Logout()
        {
            if (!IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            currentUser = null;
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}
