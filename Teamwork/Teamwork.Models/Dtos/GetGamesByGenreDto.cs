namespace Teamwork.Models.Dtos
{
    using Teamwork.Models.Enums;

    public class GetGamesByGenreDto
    {
        public string Name { get; set; }

        public bool SP { get; set; }

        public bool MP { get; set; }

        public GameGenre Genre { get; set; }
    }
}
