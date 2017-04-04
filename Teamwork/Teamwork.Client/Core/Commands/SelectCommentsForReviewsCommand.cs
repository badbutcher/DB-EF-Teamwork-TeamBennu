namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Text;
    using Services;

    public class SelectCommentsForReviewsCommand
    {
        private ReviewService reviewService;

        public SelectCommentsForReviewsCommand(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter game name to checks its reviews and comments: ");
            string gameName = Console.ReadLine();

            var result = this.reviewService.ListReviewsAndComments(gameName);

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Review title: {0,-35}\n", item.ReviewTitle);
                sb.AppendFormat("->Review content: {0,-35}\n", item.ReviewContent);
                sb.Append("-->Comments: \n");
                if (item.Comments.Count == 0)
                {
                    sb.Append("No comments");
                }
                else
                {
                    foreach (var comment in item.Comments)
                    {
                        sb.AppendFormat("---- {0,-35}\n", comment);
                    }
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
