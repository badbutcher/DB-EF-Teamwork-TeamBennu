﻿namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddCommentToReviewCommand
    {
        private ReviewService reviewService;
        private CommentService commentService;

        public AddCommentToReviewCommand(CommentService commentService, ReviewService reviewService)
        {
            this.commentService = commentService;
            this.reviewService = reviewService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter review title to comment: ");
            string reviewTitle = Console.ReadLine();

            Console.Write("Enter comment contnet: ");
            string commentContent = Console.ReadLine();

            if (!this.reviewService.DoesReviewExist(reviewTitle))
            {
                throw new ArgumentException(string.Format(ErrorMessages.ReviewDoesNotExist, reviewTitle));
            }

            this.commentService.AddComment(commentContent);

            this.commentService.AddCommentToReview(commentContent, reviewTitle);

            return $"Comment added to {reviewTitle}.";
        }
    }
}