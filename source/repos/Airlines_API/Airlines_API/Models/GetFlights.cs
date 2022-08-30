using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class GetFlights
    {
        [Key]
        [Required]
        public long FlightId { get; set; }

        [Required]
        public string FlightName { get; set; }


        [Required]
        public long Depart_airport_Id{ get; set; }

        [Required]
        public long Arrival_airport_Id { get; set; }


        [Required]
        public Nullable<DateTime> Departure_Time { get; set; }

        [Required]
        public Nullable<DateTime> Arrival_Time { get; set; }

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
