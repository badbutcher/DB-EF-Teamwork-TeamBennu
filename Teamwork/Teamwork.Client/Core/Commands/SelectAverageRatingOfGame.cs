namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Services;

    class SelectAverageRatingOfGame
    {
        private ReviewService reviewService;
        private GameService gameService;

        public SelectAverageRatingOfGame(ReviewService reviewService, GameService gameService)
        {
            this.reviewService = reviewService;
            this.gameService = gameService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter game name: ");
            string gameName = Console.ReadLine();

            if (!gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameExists, gameName));
            }

            var result = this.reviewService.GetGameByAverageRating(gameName);

            StringBuilder sb = new StringBuilder();
            if (result.Count == 0)
            {
                sb.AppendFormat($"The game {gameName} has no rating");
            }
            else
            {
                sb.AppendFormat("Game name: {0,-35}\n", result.FirstOrDefault().GameName);
                sb.AppendFormat("Average rating: {0,-5}\n\n", result.FirstOrDefault().Rating);
            }

            return sb.ToString();
        }
    }
}