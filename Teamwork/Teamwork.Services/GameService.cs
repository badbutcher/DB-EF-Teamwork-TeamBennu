namespace Teamwork.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using Models.Dtos;
    using Models.Enums;

    public class GameService
    {
        public void GreateGame(string name, bool isSingleplayer, bool isMultiplayer, DateTime? relaseDate, GameGenre gameGender, decimal gamePrice)
        {
            Game game = new Game
            {
                Name = name,
                IsSingleplayer = isSingleplayer,
                IsMultiplayer = isMultiplayer,
                RelaseDate = relaseDate,
                GameGenre = gameGender,
                Price = gamePrice
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public bool DoesGameExist(string game)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games.Any(g => g.Name == game);
                return check;
            }
        }

        public bool DoesTheGameHaveAnDeveloper(string gameName, string developerName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games
                    .SingleOrDefault(g => g.Name == gameName)
                    .Developers.Any(d => d.Name == developerName);

                return check;
            }
        }

        public void AddGameToDeveloper(string gameName, string developerName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Developer developer = context.Developers.SingleOrDefault(d => d.Name == developerName);

                developer.Games.Add(game);
                game.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        public bool DoesTheGameHaveAnPublisher(string gameName, string publisherName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Games
                    .SingleOrDefault(g => g.Name == gameName)
                    .Developers.Any(d => d.Name == publisherName);

                return check;
            }
        }

        public void AddGameToPublisher(string gameName, string publisherName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.SingleOrDefault(g => g.Name == gameName);
                Publisher publisher = context.Publishers.SingleOrDefault(d => d.Name == publisherName);

                publisher.Games.Add(game);
                game.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public List<GetGamesByGenreDto> GetGamesByGenre(string genreName)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                GameGenre genre = (GameGenre)Enum.Parse(typeof(GameGenre), genreName);

                var query = context.Games
                            .Select(g => new GetGamesByGenreDto()
                            {
                                Name = g.Name,
                                SP = g.IsSingleplayer,
                                MP = g.IsMultiplayer,
                                Genre = g.GameGenre
                            })
                            .Where(g => g.Genre == genre);

                return query.ToList();
            }
        }

        public List<Game> ListAllGames()
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var query = context.Games;
                return query.ToList();
            }
        }

        public List<string> GetAllGenres()
        {
            var result = Enum.GetValues(typeof(GameGenre))
                .Cast<GameGenre>()
                .Select(v => v.ToString())
                .ToList();

            return result;
        }

        public void BuyGame(string gameName, User currentUser)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                Game game = context.Games.FirstOrDefault(a => a.Name == gameName);
                User user = context.Users.FirstOrDefault(a => a.Username == currentUser.Username);
                if (user.Money < game.Price)
                {
                    throw new ArgumentException("You need more money to but this game.");
                }

                if (user.GamesOwned.Any(a => a.Name == game.Name))
                {
                    throw new ArgumentException($"You already own the game {game.Name}.");
                }

                user.Money -= game.Price;
                user.GamesOwned.Add(game);
                context.SaveChanges();
            }
        }
    }
}