namespace Teamwork.Client.Core.Commands
{
    using System.Text;
    using Services;

    public class SelectAllGamesCommand
    {
        private GameService gameService;

        public SelectAllGamesCommand(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(int data)
        {
            var result = this.gameService.ListAllGames();

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Name: {0,-35}\n", item.Name);
                sb.AppendFormat("SP: {0,-35}\n", item.IsSingleplayer);
                sb.AppendFormat("MP: {0,-35}\n", item.IsMultiplayer);
                sb.AppendFormat("Relase Date: {0,-35}\n\n", item.RelaseDate.Value.ToShortDateString());
            }

            return sb.ToString();
        }
    }
}
