using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines_API.Models
{
    public class FlightModel
    {
        [Key]
        public Int64 flightId { get; set; }

        public string source { get; set; }

        public string destination { get; set; }

        [Required]
        public long Depart_airport_Id { get; set; }

        [Required]
        public long Arrival_airport_Id { get; set; }

        [Required]
        public string flightName { get; set; }


        [Required]
        public Nullable<DateTime> Departure_Time { get; set; }

        [Required]

        public Nullable<DateTime> Arrival_Time { get; set; }

        [Required]
        public decimal Economy_Fare { get; set; }


        [Required]
        public decimal Business_Fare { get; set; }


        

        [Required]
        public int Total_Business_Seats { get; set; }

        [Required]
        public int Total_Economy_Seats { get; set; }
    }
}
