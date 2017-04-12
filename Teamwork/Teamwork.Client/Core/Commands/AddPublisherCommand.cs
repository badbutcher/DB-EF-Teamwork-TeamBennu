namespace Teamwork.Client.Core.Commands
{
    using System;
    using Services;

    public class AddPublisherCommand
    {
        private PublisherService publisherService;

        public AddPublisherCommand(PublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        public string Execute(int data)
        {
            Console.Write("Enter publisher name: ");
            string name = Console.ReadLine();

            Console.Write("Enter publisher founded location: ");
            string countryName = Console.ReadLine();
            if (countryName == string.Empty)
            {
                countryName = "Unknown";
            }

            Console.Write("Enter city founded location: ");
            string cityName = Console.ReadLine();
            if (cityName == string.Empty)
            {
                cityName = "Unknown";
            }

            Console.Write("Enter founded date: ");
            DateTime founded = DateTime.Parse(Console.ReadLine());

            if (this.publisherService.DoesPublisherExist(name))
            {
                throw new ArgumentException(string.Format(ErrorMessages.PublisherExists, name));
            }

            this.publisherService.GreatePublisher(name, countryName, cityName, founded);

            return $"Publisher {name} was added.";
        }
    }
}