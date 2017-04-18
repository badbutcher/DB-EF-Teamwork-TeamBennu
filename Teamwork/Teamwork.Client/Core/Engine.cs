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
                    int input = int.Parse(Console.ReadLine());
                    int data = input;
                    string result = this.commandDispatcher.DispatchCommand(data);
                    this.Success(result);
                }
                catch (Exception e)
                {
                    this.Error(e);
                }
            }
        }

        private void PrintOptions()
        {
            if (AuthenticationManager.GetCurrentUser() == null)
            {
                Console.WriteLine("1 - Register user");
                Console.WriteLine("2 - Login user");
            }
            else if (AuthenticationManager.GetCurrentUser().Username == "Admin")
            {
                Console.WriteLine("1 - Add new game.");
                Console.WriteLine("2 - Add new developer.");
                Console.WriteLine("3 - Add developer to a game.");
                Console.WriteLine("4 - Add new publisher.");
                Console.WriteLine("5 - Add publisher to a game.");
                Console.WriteLine("6 - Logout");
            }
            else if (AuthenticationManager.GetCurrentUser() != null && AuthenticationManager.GetCurrentUser().Username != "Admin")
            {
                Console.WriteLine("1 - Add review to a game.");
                Console.WriteLine("2 - Add comment to a review.");
                Console.WriteLine("3 - View games by there genre.");
                Console.WriteLine("4 - View games by a given minimum rating.");
                Console.WriteLine("5 - List all games.");
                Console.WriteLine("6 - View reviews and comments for a given game.");
                Console.WriteLine("7 - View developers and there games.");
                Console.WriteLine("8 - View publishers and there games.");
                Console.WriteLine("9 - View game by its average rating.");
                Console.WriteLine("10 - Buy game");
                Console.WriteLine("11 - My info");
                Console.WriteLine("12 - Add money");
                Console.WriteLine("13 - Logout");
            }

            Console.WriteLine("99 - Exit");
        }

        private void Error(Exception e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.Beep(500, 600);
            Console.Beep(300, 800);
        }

        private void Success(string result)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ResetColor();
            Console.Beep(300, 100);
            Console.Beep(400, 100);
            Console.Beep(500, 100);
            Console.Beep(600, 100);
        }
    }
}