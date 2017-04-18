namespace Teamwork.Client.Core.Commands
{
    using Models;
    using Services;

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