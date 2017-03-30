using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Models.Dtos
{
    public class GetCommentsAndReviewsDto
    {
        public string GameName { get; set; }

        public string ReviewTitle { get; set; }

        public string ReviewContent { get; set; }

        public List<string> Comments { get; set; }
    }
}
