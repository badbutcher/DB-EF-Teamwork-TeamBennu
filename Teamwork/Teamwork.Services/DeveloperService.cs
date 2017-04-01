namespace Teamwork.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Models.Dtos;
    using System.Collections.Generic;

    public class DeveloperService
    {
        public void GreateDeveloper(string name, string countryName, string cityName, DateTime founded)
        {
            Developer developer = new Developer
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                DateFounded = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        public bool DoesDeveloperExist(string name)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Developers.Any(g => g.Name == name);
                return check;
            }
        }

        public List<GetDevelopersAndGamesDto> GetDevelopersAndGames()
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var query = context.Developers
                            .Select(d => new GetDevelopersAndGamesDto()
                            {
                                DeveloperName = d.Name,
                                FoundedInCityName = d.FoundedInCityName,
                                FoundedInCountryName = d.FoundedInCountryName,
                                DateFounded = d.DateFounded,
                                GamesMade = d.Games.Select(g => g.Name).ToList()
                            });

                return query.ToList();
            }
        }
    }
}