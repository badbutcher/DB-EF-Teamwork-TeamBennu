namespace Teamwork.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.GamesOwned = new HashSet<Game>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Username { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public decimal Money { get; set; }

        [Required]
        public int CreditCardNumber { get; set; }

        public virtual ICollection<Game> GamesOwned { get; set; }
    }
}