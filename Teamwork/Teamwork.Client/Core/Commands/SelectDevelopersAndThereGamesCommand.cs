namespace Teamwork.Client.Core.Commands
{
    using System.Text;
    using Services;

    public class SelectDevelopersAndThereGamesCommand
    {
        private DeveloperService developerService;

        public SelectDevelopersAndThereGamesCommand(DeveloperService developerService)
        {
            this.developerService = developerService;
        }

        public string Execute(int data)
        {
            var result = this.developerService.GetDevelopersAndGames();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Developer name: {0,-35}\n", item.DeveloperName);
                sb.AppendFormat("Country: {0,-20} | City: {1,-20}\n", item.FoundedInCountryName, item.FoundedInCityName);
                sb.AppendFormat("Founded in: {0,-35}\n", item.DateFounded);
                sb.Append("Games made:\n");
                foreach (var game in item.GamesMade)
                {
                    sb.AppendFormat("-- {0}\n", game);
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}