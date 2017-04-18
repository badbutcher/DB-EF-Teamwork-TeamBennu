namespace Teamwork.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Models.Dtos;

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

        //public bool CheckCreditCardNumber(int number)
        //{
        //    using (TeamworkContext context = new TeamworkContext())
        //    {
        //        var result = context.Users.Any(a => a.CreditCardNumber == number);

        //        return result;
        //    }
        //}

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

        public List<UserInfoDto> UserInfo(User user)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Users
                    .Where(u => u.Username == user.Username)
                    .Select(a => new UserInfoDto()
                    {
                        Username = a.Username,
                        Money = a.Money,
                        GamesOwned = a.GamesOwned.Select(d => d.Name).ToList()
                    });

                return result.ToList();
            }
        }


        //public void AddMoney(int credit, decimal money, User user)
        //{
        //    using (TeamworkContext context = new TeamworkContext())
        //    {
        //        var creditNumber = context.Users.FirstOrDefault(a => a.CreditCardNumber == credit);
        //        User u = context.Users.FirstOrDefault(a => a.Username == user.Username);

        //        u.Money += money;
        //        context.SaveChanges();
        //    }
        //}
    }
}