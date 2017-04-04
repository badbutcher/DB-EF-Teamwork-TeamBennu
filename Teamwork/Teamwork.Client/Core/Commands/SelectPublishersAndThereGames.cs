namespace Teamwork.Client.Core.Commands
{
    using System.Text;
    using Services;

    public class SelectPublishersAndThereGames
    {
        private PublisherService publisherService;

        public SelectPublishersAndThereGames(PublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        public string Execute(int data)
        {
            var result = this.publisherService.GetPublishersAndGames();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Publisher name: {0,-35}\n", item.PublisherName);
                sb.AppendFormat("Country: {0,-20} | City: {1,-20}\n", item.FoundedInCountryName, item.FoundedInCityName);
                sb.AppendFormat("Founded in: {0,-35}\n", item.DateFounded);
                sb.Append("Games published:\n");
                if (item.GamesMade.Count == 0)
                {
                    sb.Append("-- None\n");
                }
                else
                {
                    foreach (var game in item.GamesMade)
                    {
                        sb.AppendFormat("-- {0}\n", game);
                    }
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}