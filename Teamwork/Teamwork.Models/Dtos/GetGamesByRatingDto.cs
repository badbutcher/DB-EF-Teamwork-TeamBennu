﻿namespace Teamwork.Models.Dtos
{
    public class GetGamesByRatingDto
    {
        public string GameName { get; set; }

        public string ReviewTitle { get; set; }

        public string ReviewContnet { get; set; }

        public float Rating { get; set; }
    }
}