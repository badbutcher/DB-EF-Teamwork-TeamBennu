using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Data;
using Teamwork.Models;

namespace Teamwork.Services
{
    public class UserService
    {
        public void RegisterUser(string username, string password, decimal money)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                User u = new User
                {
                    Username = username,
                    Password = password,
                    Money = money
                };

                context.Users.Add(u);
                context.SaveChanges();
            }
        }

        public bool IsUsernameTaken(string username)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Users.Any(a => a.Username == username);

                return result;
            }
        }

        public User GetUserByCredentials(string username, string password)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                return user;
            }
        }
    }
}