using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Data;
using Teamwork.Models;
using Teamwork.Services;

namespace Teamwork.Client.Core.Commands
{
    public class BuyGameCommand
    {
        private GameService gameService;

        public BuyGameCommand(GameService gameService)
        {
            this.gameService = gameService;

        }

        public string Execute(int data)
        {
            string gameName = Console.ReadLine();

            this.BuyGame(gameName, AuthenticationManager.GetCurrentUser());

            return "yes";
        }

        public void BuyGame(string gameName, User currentUser)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                User user = currentUser;
                Game game = context.Games.FirstOrDefault(a => a.Name == gameName);
                User db = context.Users.FirstOrDefault(a => a.Username == user.Username);
                db.Money -= game.Price;
                db.GamesOwned.Add(game);
                context.SaveChanges();
            }
        }
    }
}