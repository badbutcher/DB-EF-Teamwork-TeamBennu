namespace Teamwork.Client.Core
{
    using Commands;
    using Services;
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(int commandType)
        {
            GameService gameService = new GameService();
            DeveloperService developerService = new DeveloperService();
            PublisherService publisherService = new PublisherService();
            ReviewService reviewService = new ReviewService();
            CommentService commentService = new CommentService();
            UserService userService = new UserService();

            Console.Clear();
            string result = string.Empty;

            if (AuthenticationManager.GetCurrentUser() == null)
            {
                switch (commandType)
                {
                    case 1:
                        UserRegisterCommand userRegisterCommand = new UserRegisterCommand(userService);
                        result = userRegisterCommand.Execute(commandType);
                        break;
                    case 2:
                        UserLoginCommand userLoginCommand = new UserLoginCommand(userService);
                        result = userLoginCommand.Execute(commandType);
                        break;
                    case 99:
                        ExitCommand exit = new ExitCommand();
                        exit.Execute();
                        break;
                    default:
                        throw new FormatException("Unknow command. Try commands from 1 to 13 or 99 to exit.");
                }
            }
            else if (AuthenticationManager.GetCurrentUser().Username == "Admin")
            {
                switch (commandType)
                {
                    case 1:
                        AddGameCommand addGame = new AddGameCommand(gameService);
                        result = addGame.Execute(commandType);
                        break;
                    case 2:
                        AddDeveloperCommand addDeveloper = new AddDeveloperCommand(developerService);
                        result = addDeveloper.Execute(commandType);
                        break;
                    case 3:
                        AddGameToDeveloperCommand addGameToDeveloper = new AddGameToDeveloperCommand(gameService, developerService);
                        result = addGameToDeveloper.Execute(commandType);
                        break;
                    case 4:
                        AddPublisherCommand addPublisher = new AddPublisherCommand(publisherService);
                        result = addPublisher.Execute(commandType);
                        break;
                    case 5:
                        AddGameToPublisherCommand addGameToPublisher = new AddGameToPublisherCommand(gameService, publisherService);
                        result = addGameToPublisher.Execute(commandType);
                        break;
                    case 6:
                        UserLogoutCommand userLogoutCommand = new UserLogoutCommand(userService);
                        result = userLogoutCommand.Execute(commandType);
                        break;
                    case 99:
                        ExitCommand exit = new ExitCommand();
                        exit.Execute();
                        break;
                    default:
                        throw new FormatException("Unknow command. Try commands from 1 to 13 or 99 to exit.");
                }
            }
            else if (AuthenticationManager.GetCurrentUser() != null && AuthenticationManager.GetCurrentUser().Username != "Admin")
            {
                switch (commandType)
                {
                    case 1:
                        AddReviewToGameCommand addReviewCommand = new AddReviewToGameCommand(reviewService, gameService);
                        result = addReviewCommand.Execute(commandType);
                        break;
                    case 2:
                        AddCommentToReviewCommand addCommentCommand = new AddCommentToReviewCommand(commentService, reviewService);
                        result = addCommentCommand.Execute(commandType);
                        break;
                    case 3:
                        SelectGameByGenre selectGameByGenre = new SelectGameByGenre(gameService);
                        result = selectGameByGenre.Execute(commandType);
                        break;
                    case 4:
                        SelectGameReviewRating selectGameByRating = new SelectGameReviewRating(reviewService);
                        result = selectGameByRating.Execute(commandType);
                        break;
                    case 5:
                        SelectAllGamesCommand selectAllGamesCommand = new SelectAllGamesCommand(gameService);
                        result = selectAllGamesCommand.Execute(commandType);
                        break;
                    case 6:
                        SelectCommentsForReviewsCommand selectCommentsForReviewsCommand = new SelectCommentsForReviewsCommand(reviewService, gameService);
                        result = selectCommentsForReviewsCommand.Execute(commandType);
                        break;
                    case 7:
                        SelectDevelopersAndThereGamesCommand selectDevelopersAndThereGamesCommand = new SelectDevelopersAndThereGamesCommand(developerService);
                        result = selectDevelopersAndThereGamesCommand.Execute(commandType);
                        break;
                    case 8:
                        SelectPublishersAndThereGames selectPublishersAndThereGames = new SelectPublishersAndThereGames(publisherService);
                        result = selectPublishersAndThereGames.Execute(commandType);
                        break;
                    case 9:
                        SelectAverageRatingOfGame selectAverageRatingOfGame = new SelectAverageRatingOfGame(reviewService, gameService);
                        result = selectAverageRatingOfGame.Execute(commandType);
                        break;
                    case 10:
                        BuyGameCommand buyGameCommand = new BuyGameCommand(gameService);
                        result = buyGameCommand.Execute(commandType);
                        break;
                    case 11:
                        UserInfoCommand userInfoCommand = new UserInfoCommand(userService);
                        result = userInfoCommand.Execute(commandType);
                        break;
                    case 12:
                        UserLogoutCommand userLogoutCommand = new UserLogoutCommand(userService);
                        result = userLogoutCommand.Execute(commandType);
                        break;
                    case 99:
                        ExitCommand exit = new ExitCommand();
                        exit.Execute();
                        break;
                    default:
                        throw new FormatException("Unknow command.");
                }
            }

            return result;
        }
    }
}