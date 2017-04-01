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
            Console.Clear();
            string result = string.Empty;

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
                    AddReviewToGameCommand addReviewCommand = new AddReviewToGameCommand(reviewService, gameService);
                    result = addReviewCommand.Execute(commandType);
                    break;
                case 7:
                    AddCommentToReviewCommand addCommentCommand = new AddCommentToReviewCommand(commentService, reviewService);
                    result = addCommentCommand.Execute(commandType);
                    break;
                case 8:
                    SelectGameByGenre selectGameByGenre = new SelectGameByGenre(gameService);
                    result = selectGameByGenre.Execute(commandType);
                    break;
                case 9:
                    SelectGameReviewRating selectGameByRating = new SelectGameReviewRating(reviewService);
                    result = selectGameByRating.Execute(commandType);
                    break;
                case 10:
                    SelectAllGamesCommand selectAllGamesCommand = new SelectAllGamesCommand(gameService);
                    result = selectAllGamesCommand.Execute(commandType);
                    break;
                case 11:
                    SelectCommentsForReviewsCommand selectCommentsForReviewsCommand = new SelectCommentsForReviewsCommand(reviewService);
                    result = selectCommentsForReviewsCommand.Execute(commandType);
                    break;
                case 12:
                    SelectDevelopersAndThereGamesCommand selectDevelopersAndThereGamesCommand = new SelectDevelopersAndThereGamesCommand(developerService);
                    result = selectDevelopersAndThereGamesCommand.Execute(commandType);
                    break;
                case 13:
                    SelectPublishersAndThereGames selectPublishersAndThereGames = new SelectPublishersAndThereGames(publisherService);
                    result = selectPublishersAndThereGames.Execute(commandType);
                    break;
                case 99:
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    Console.WriteLine("Unknow command");
                    break;
            }

            return result;
        }
    }
}