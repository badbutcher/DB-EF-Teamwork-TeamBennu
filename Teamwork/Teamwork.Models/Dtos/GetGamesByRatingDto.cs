namespace Teamwork.Models.Dtos
{
    public class GetGamesByRatingAnonymous
    {
        public string GameName { get; set; }

        public string ReviewTitle { get; set; }

        public string ReviewContnet { get; set; }

        public float Rating { get; set; }
    }
}