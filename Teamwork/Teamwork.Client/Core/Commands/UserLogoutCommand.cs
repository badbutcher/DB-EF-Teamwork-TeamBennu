using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class UserLogoutCommand
    {
        private UserService userService;

        public UserLogoutCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            AuthenticationManager.Athorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}
