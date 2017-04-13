using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class UserLoginCommand
    {
        private UserService userService;

        public UserLoginCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter username : ");
            string username = Console.ReadLine();

            Console.Write("Enter password :");
            string password = Console.ReadLine();

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(ErrorMessages.LogoutFirst);
            }

            User user = userService.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.WrongUsernameOrPassword);
            }

            AuthenticationManager.Login(user);

            return $"User {user.Username} successfully logged in!";
        }
    }
}