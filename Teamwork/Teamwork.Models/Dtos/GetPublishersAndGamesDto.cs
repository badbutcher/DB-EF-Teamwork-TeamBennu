namespace Teamwork.Models.Dtos
{
    using System;
    using System.Collections.Generic;

    public class GetPublishersAndGamesDto
    {
        public string PublisherName { get; set; }

        public string FoundedInCountryName { get; set; }

        public string FoundedInCityName { get; set; }

        public DateTime? DateFounded { get; set; }

        public List<string> GamesMade { get; set; }
    }
}