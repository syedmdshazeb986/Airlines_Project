using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_API.Models
{
    public class Flight
    {
        [Key]
      

        [Required]
        public string flightName { get; set; }

        [Required]
        public long depart_airport_id { get; set; }

        [Required]
        public long arrival_airport_id { get; set; }

        [Required]
        public Nullable<DateTime> departure_time { get; set; }

        [Required]
        public Nullable<DateTime> arrival_time { get; set; }

        [Required]
        public decimal economy_fare { get; set; }

        [Required]
        public decimal business_fare { get; set; }

        

    }
}
