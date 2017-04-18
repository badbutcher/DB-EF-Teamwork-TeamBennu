namespace Teamwork.Client.Core.Commands
{
    using System;
    using Models;
    using Services;

    public class UserAddMoneyCommand
    {
        private UserService userService;

        public UserAddMoneyCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter credit card number: ");
            int credit = int.Parse(Console.ReadLine());

            Console.Write("Enter money amount to transfer: ");
            decimal money = decimal.Parse(Console.ReadLine());

            if (money < 0)
            {
                throw new ArgumentException(ErrorMessages.NegativeMoney);
            }

            User user = AuthenticationManager.GetCurrentUser();

            userService.AddMoney(credit, money, user);

            return $"{money} was transferd to {user.Username}";
        }
    }
}