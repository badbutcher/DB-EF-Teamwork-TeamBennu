namespace Teamwork.Client.Core.Commands
{
    using System;
    using Models;
    using Services;

    public class UserLoginCommand
    {
        private UserService userService;

        public UserLoginCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(ErrorMessages.LogoutFirst);
            }

            User user = this.userService.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(ErrorMessages.WrongUsernameOrPassword);
            }

            AuthenticationManager.Login(user);

            return $"User {user.Username} successfully logged in!";
        }
    }
}