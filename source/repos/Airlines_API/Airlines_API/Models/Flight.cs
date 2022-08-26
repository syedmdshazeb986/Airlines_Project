using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_API.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public long FlightId { get; set; }

        [Required]
        public string FlightName { get; set; }

        [Required]
        public long Depart_airport_id { get; set; }

        [Required]
        public long Arrival_airport_id { get; set; }

        [Required]
        public Nullable<DateTime> Departure_time { get; set; }

        [Required]
        public Nullable<DateTime> Arrival_time { get; set; }

        [Required]
        public decimal Economy_fare { get; set; }

        [Required]
        public decimal Business_fare { get; set; }

        [Required]
        public int Total_Business_Seats { get; set; }

        [Required]
        public int Total_Economy_Seats { get; set; }

        

    }
}
