namespace Teamwork.Client.Core
{
    public class ErrorMessages
    {
        public const string ReviewDoesNotExist = "Review title {0} does not exist.";
        public const string DeveloperExists = "Developer {0} already exist.";
        public const string GameExists = "Game {0} already exist.";
        public const string GameDoesNotExists = "Game {0} does not exist.";
        public const string GameHasDeveloper = "{0} is already made by {1}.";
        public const string PublisherExists = "Publisher {0} already exist.";
        public const string GameHasPublisher = "{0} is already published by {1}.";
        public const string RatingRange = "Rating must be in range 1-10.";
        public const string ReviewTitleTaken = "The title {0} is already used.";
        public const string GamePrice = "Game can't have negative price.";

        public const string LogoutFirst = "You should logout first.";
        public const string LoginFirst = "You should login first.";
        public const int UsernameMinLenght = 3;
        public const int UsernameMaxLenght = 15;
        public const string UsernameLenght = "The username has to be between 3 and 15 symbols.";
        public const string UsernameTaken = "The username {0} has been taken.";
        public const string PasswordNotValid = "Password must have one uppercase symbol.";
        public const string PasswordMatch = "Passwords do not match.";
        public const string NegativeMoney = "Money must be more than 0.";
        public const string WrongUsernameOrPassword = "Invalid username or password.";
        public const string CreditCard = "This credit card is in use.";
    }
}