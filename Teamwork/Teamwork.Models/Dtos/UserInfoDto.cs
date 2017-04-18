using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Models.Dtos
{
    public class UserInfoDto
    {
        public string Username { get; set; }

        public decimal Money { get; set; }

        public List<string> GamesOwned { get; set; }
    }
}
