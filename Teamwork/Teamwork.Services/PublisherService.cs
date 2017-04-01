namespace Teamwork.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using System.Collections.Generic;
    using Models.Dtos;

    public class PublisherService
    {
        public void GreatePublisher(string name, string countryName, string cityName, DateTime founded)
        {
            Publisher publisher = new Publisher
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                FoundedIn = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public bool DoesPublisherExist(string name)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Publishers.Any(g => g.Name == name);
                return check;
            }
        }

        public List<GetPublishersAndGamesDto> GetPublishersAndGames()
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var query = context.Publishers
                            .Select(d => new GetPublishersAndGamesDto()
                            {
                                PublisherName = d.Name,
                                FoundedInCityName = d.FoundedInCityName,
                                FoundedInCountryName = d.FoundedInCountryName,
                                DateFounded = d.FoundedIn,
                                GamesMade = d.Games.Select(g => g.Name).ToList()
                            });

                return query.ToList();
            }
        }
    }
}