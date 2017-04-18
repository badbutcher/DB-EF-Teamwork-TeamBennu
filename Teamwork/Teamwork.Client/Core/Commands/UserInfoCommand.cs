namespace Teamwork.Client.Core.Commands
{
    using System.Text;
    using Models;
    using Services;

    public class UserInfoCommand
    {
        private UserService userService;

        public UserInfoCommand(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(int data)
        {
            User user = AuthenticationManager.GetCurrentUser();

            var result = this.userService.UserInfo(user);

            StringBuilder sb = new StringBuilder();

            foreach (var u in result)
            {
                sb.AppendFormat("Username: {0}\n", u.Username);
                sb.AppendFormat("Money: {0}\n", u.Money);
                sb.Append("My games:");
                if (u.GamesOwned.Count == 0)
                {
                    sb.Append("None");
                }
                else
                {
                    foreach (var item in u.GamesOwned)
                    {
                        sb.AppendFormat("-- {0}\n", item);
                    }
                }
            }

            return sb.ToString();
        }
    }
}