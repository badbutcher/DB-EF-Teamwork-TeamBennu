using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class UserAddMoneyCommand
    {
        //private UserService userService;

        //public UserAddMoneyCommand(UserService userService)
        //{
        //    this.userService = userService;
        //}

        //public string Execute(int data)
        //{
        //    Console.Write("Enter credit card number: ");
        //    int credit = int.Parse(Console.ReadLine());

        //    if (userService.CheckCreditCardNumber(credit))
        //    {
        //        throw new ArgumentException(ErrorMessages.CreditCard);
        //    }

        //    Console.Write("Enter money amount to transfer: ");
        //    decimal money = decimal.Parse(Console.ReadLine());

        //    if (money < 0)
        //    {
        //        throw new ArgumentException(ErrorMessages.NegativeMoney);
        //    }

        //    User user = AuthenticationManager.GetCurrentUser();

        //    userService.AddMoney(credit, money, user);

        //    return $"User {user.Username} successfully logged in!";
        //}
    }
}
