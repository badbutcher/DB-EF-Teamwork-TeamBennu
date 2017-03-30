namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Text;
    using Services;

    public class SelectGameReviewRating
    {
        private ReviewService reviewService;

        public SelectGameReviewRating(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public string Execute(string data)
        {
            Console.Write("Enter minimum game rating: ");
            float gameRating = float.Parse(Console.ReadLine());

            var result = this.reviewService.GetGamesByRating(gameRating);

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Game name: {0,-35}\n", item.GameName);
                sb.AppendFormat("Title: {0,-30}\n", item.ReviewTitle);
                sb.AppendFormat("Contnet: {0,-30}\n", item.ReviewContnet);
                sb.AppendFormat("Rating: {0,-5}\n\n", item.Rating);
            }

            return sb.ToString();
        }
    }
}