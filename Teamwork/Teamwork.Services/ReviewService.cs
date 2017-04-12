namespace Teamwork.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Models.Dtos;

    public class ReviewService
    {
        public void GreateReview(string name, string content, float rating, string gameName)
        {
            Review review = new Review
            {
                Name = name,
                Content = content,
                Rating = rating,
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }

        public void AddReviewToGame(string gameName, string reviewTitle)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Review review = context.Reviews.SingleOrDefault(r => r.Name == reviewTitle);
                game.Reviews.Add(review);
                context.SaveChanges();
            }
        }

        public bool DoesReviewExist(string reviewTitle)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Reviews.Any(r => r.Name == reviewTitle);
                return check;
            }
        }

        public bool IsRatingValid(float rating)
        {
            if (rating <= 10 && rating >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<GetGamesByRatingDto> GetGamesByRating(float rating)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Reviews
                    .Select(g => new GetGamesByRatingDto()
                    {
                        GameName = g.Game.Name,
                        ReviewTitle = g.Name,
                        ReviewContnet = g.Content,
                        Rating = g.Rating
                    })
                    .Where(g => g.Rating >= rating)
                    .OrderBy(r => r.Rating)
                    .ThenBy(r => r.GameName);

                return result.ToList();
            }
        }

        public List<GetCommentsAndReviewsDto> ListReviewsAndComments(string gameName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Reviews
                    .Select(c => new GetCommentsAndReviewsDto()
                    {
                        GameName = c.Game.Name,
                        ReviewTitle = c.Name,
                        ReviewContent = c.Content,
                        Comments = c.Comments.Select(g => g.Content).ToList()
                    })
                    .Where(g => g.GameName == gameName);

                return result.ToList();
            }
        }

        public List<GetGameByAverageRatingDto> GetGameByAverageRating(string gameName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var result = context.Reviews
                    .Select(g => new GetGameByAverageRatingDto()
                    {
                        GameName = g.Game.Name,
                        Rating = g.Game.Reviews.Average(a => a.Rating)
                    })
                    .Where(g => g.GameName == gameName);

                return result.ToList();
            }
        }
    }
}