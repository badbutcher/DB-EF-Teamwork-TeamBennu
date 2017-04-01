﻿namespace Teamwork.Client
{
    using Core;
    using Data;

    class Startup
    {
        static void Main()
        {
            TeamworkContext context = new TeamworkContext();
            ////context.Database.Initialize(true);

            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }
    }
}
