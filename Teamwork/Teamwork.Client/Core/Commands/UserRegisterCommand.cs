using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class UserRegisterCommand
    {
        private UserService userService;

        public UserRegisterCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter username : ");
            string username = Console.ReadLine();

            if (userService.IsUsernameTaken(username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.UsernameTaken, username));
            }

            if (username.Length < ErrorMessages.UsernameMinLenght || username.Length > ErrorMessages.UsernameMaxLenght)
            {
                throw new ArgumentException(ErrorMessages.UsernameLenght);
            }

            Console.Write("Enter password with at least one uppercase :");
            string password = Console.ReadLine();

            if (!password.Any(char.IsUpper) || password.Length < 6)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PasswordNotValid, password));
            }

            Console.Write("Repeat password : ");
            string repeatPassword = Console.ReadLine();

            if (password != repeatPassword)
            {
                throw new ArgumentException(ErrorMessages.PasswordNotValid);
            }

            Console.Write("Deposit some money : ");
            decimal money = decimal.Parse(Console.ReadLine());

            if (money < 0)
            {
                throw new ArgumentException(ErrorMessages.NegativeMoney);
            }

            userService.RegisterUser(username, password, money);

            return $"User {username} successfully registered!";
        }
    }
}
