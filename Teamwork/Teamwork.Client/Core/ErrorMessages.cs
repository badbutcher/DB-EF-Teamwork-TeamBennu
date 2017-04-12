namespace Teamwork.Client.Core
{
    public class ErrorMessages
    {
        public const string ReviewDoesNotExist = "Review title {0} does not exist.";
        public const string DeveloperExists = "Developer {0} already exist.";
        public const string GameExists = "Game {0} already exist.";
        public const string GameHasDeveloper = "{0} is already made by {1}.";
        public const string PublisherExists = "Publisher {0} already exist.";
        public const string GameHasPublisher = "{0} is already published by {1}.";
        public const string RatingRange = "Rating must be in range 1-10.";
        public const string ReviewTitleTaken = "The title {0} is already used.";
    }
}