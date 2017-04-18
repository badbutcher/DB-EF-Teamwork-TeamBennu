namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class BuyGameCommand
    {
        private GameService gameService;

        public BuyGameCommand(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter game name you wish to buy: ");
            string gameName = Console.ReadLine();

            this.gameService.BuyGame(gameName, AuthenticationManager.GetCurrentUser());

            return $"You just bought the game {gameName}";
        }
    }
}