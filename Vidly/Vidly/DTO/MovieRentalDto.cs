using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieRentalDto
    {
        public int CustomerId { get; set; }

        public List<int> MovieId { get; set; }
    }
}