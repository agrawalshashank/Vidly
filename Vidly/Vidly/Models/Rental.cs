using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateRented { get; set; }

        public DateTime? DateReturn { get; set; }

        [Required]
        public Customer Customer { get; set; }


        public int CustomerId { get; set; }

        [Required]
        public Movie Movie { get; set; }

    }
}