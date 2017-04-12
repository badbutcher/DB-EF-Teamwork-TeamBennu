namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddReviewToGameCommand
    {
        private GameService gameService;
        private ReviewService reviewService;

        public AddReviewToGameCommand(ReviewService reviewService, GameService gameService)
        {
            this.reviewService = reviewService;
            this.gameService = gameService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter review title : ");
            string title = Console.ReadLine();

            if (this.reviewService.DoesReviewExist(title))
            {
                throw new ArgumentException(string.Format(ErrorMessages.ReviewTitleTaken, title));
            }

            Console.Write("Enter contnet : ");
            string content = Console.ReadLine();

            Console.Write("Enter rating (1-10) : ");
            float rating = float.Parse(Console.ReadLine());

            if (!reviewService.IsRatingValid(rating))
            {
                throw new ArgumentException(ErrorMessages.RatingRange);
            }

            Console.Write("Enter game name for the review : ");
            string gameName = Console.ReadLine();

            if (!this.gameService.DoesGameExist(gameName))
            {
                throw new ArgumentException(string.Format(ErrorMessages.GameExists, gameName));
            }

            this.reviewService.GreateReview(title, content, rating, gameName);

            this.reviewService.AddReviewToGame(gameName, title);

            return $"Review {title} was added to the game {gameName}.";
        }
    }
}