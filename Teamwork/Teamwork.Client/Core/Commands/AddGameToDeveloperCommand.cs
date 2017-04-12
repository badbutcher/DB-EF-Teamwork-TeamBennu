namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddGameToDeveloperCommand
    {
        private GameService gameService;
        private DeveloperService developerService;

        public AddGameToDeveloperCommand(GameService gameService, DeveloperService developerService)
        {
            this.gameService = gameService;
            this.developerService = developerService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter game name : ");
            string gameName = Console.ReadLine();

            Console.Write("Enter developer name: ");
            string developerName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameExists, gameName));
            }

            if (!this.developerService.DoesDeveloperExist(developerName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.DeveloperExists, developerName));
            }

            if (this.gameService.DoesTheGameHaveAnDeveloper(gameName, developerName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameHasDeveloper, gameName, developerName));
            }

            this.gameService.AddGameToDeveloper(gameName, developerName);

            return $"{developerName} has made the game {gameName}.";
        }
    }
}