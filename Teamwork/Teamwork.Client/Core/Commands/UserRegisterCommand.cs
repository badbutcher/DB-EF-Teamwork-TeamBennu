namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Services;

    public class UserRegisterCommand
    {
        private UserService userService;

        public UserRegisterCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter username (min 3 chars): ");
            string username = Console.ReadLine();

            if (this.userService.IsUsernameTaken(username))
            {
                throw new ArgumentException(string.Format(ErrorMessages.UsernameTaken, username));
            }

            if (username.Length < ErrorMessages.UsernameMinLenght || username.Length > ErrorMessages.UsernameMaxLenght)
            {
                throw new ArgumentException(ErrorMessages.UsernameLenght);
            }

            Console.Write("Enter password with at least one uppercase (min 6 chars): ");
            string password = Console.ReadLine();

            if (!password.Any(char.IsUpper) || password.Length < 6)
            {
                throw new ArgumentException(string.Format(ErrorMessages.PasswordNotValid, password));
            }

            Console.Write("Repeat password: ");
            string repeatPassword = Console.ReadLine();

            if (password != repeatPassword)
            {
                throw new ArgumentException(ErrorMessages.PasswordNotValid);
            }

            //Console.Write("Enter credit card number (10 chars): ");
            //int creditCardNumber = int.Parse(Console.ReadLine());

            //if (userService.CheckCreditCardNumber(creditCardNumber))
            //{
            //    throw new ArgumentException(ErrorMessages.CreditCard);
            //}

            Console.Write("Deposit some money: ");
            decimal money = decimal.Parse(Console.ReadLine());

            if (money < 0)
            {
                throw new ArgumentException(ErrorMessages.NegativeMoney);
            }

            this.userService.RegisterUser(username, password, money);

            return $"User {username} successfully registered!";
        }
    }
}