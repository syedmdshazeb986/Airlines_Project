using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class Passenger
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Phone_Number { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]

        public string Gender { get; set; }

        [Required]

        public long SeatId { get; set; }
    }
}
