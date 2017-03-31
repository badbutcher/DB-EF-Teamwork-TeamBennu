namespace Teamwork.Client.Core
{
    using System;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    this.PrintOptions();
                    string input = Console.ReadLine().Trim();
                    string data = input;
                    string result = this.commandDispatcher.DispatchCommand(data);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void PrintOptions()
        {
            Console.WriteLine("1 - Add new game.");
            Console.WriteLine("2 - Add new developer.");
            Console.WriteLine("3 - Add developer to a game.");
            Console.WriteLine("4 - Add new publisher.");
            Console.WriteLine("5 - Add publisher to a game.");
            Console.WriteLine("6 - Add review to a game.");
            Console.WriteLine("7 - Add comment to a review.");
            Console.WriteLine("8 - View games by there genre.");
            Console.WriteLine("9 - View games by a given minimum rating.");
            Console.WriteLine("10 - List all games.");
            Console.WriteLine("11 - View reviews and comments for a given game.");
            Console.WriteLine("12 - Exit");
        }
    }
}