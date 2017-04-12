namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddGameToPublisherCommand
    {
        private GameService gameService;
        private PublisherService publisherService;

        public AddGameToPublisherCommand(GameService gameService, PublisherService publisherService)
        {
            this.gameService = gameService;
            this.publisherService = publisherService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter game name: ");
            string gameName = Console.ReadLine();

            Console.Write("Enter publisher name: ");
            string publisherName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameExists, gameName));
            }

            if (!this.publisherService.DoesPublisherExist(publisherName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.PublisherExists, publisherName));
            }

            if (this.gameService.DoesTheGameHaveAnPublisher(gameName, publisherName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameHasPublisher, gameName, publisherName));
            }

            this.gameService.AddGameToPublisher(gameName, publisherName);

            return $"{publisherName} now publishes the game {gameName}.";
        }
    }
}