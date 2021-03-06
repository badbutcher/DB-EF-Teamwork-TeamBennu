﻿namespace Teamwork.Client.Core.Commands
{
    using System;
    using System.Text;
    using Services;

    public class SelectGameByGenre
    {
        private GameService gameService;

        public SelectGameByGenre(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter Genre ({0}): ", string.Join(", ", this.gameService.GetAllGenres()));
            string genre = Console.ReadLine().ToUpper();

            var result = this.gameService.GetGamesByGenre(genre);

            StringBuilder sb = new StringBuilder();

            foreach (var item in result)
            {
                sb.AppendFormat("Name: {0,-35} | SP: {1,-5} | MP: {2,-5}\n", item.Name, item.SP, item.MP);
            }

            return sb.ToString();
        }
    }
}