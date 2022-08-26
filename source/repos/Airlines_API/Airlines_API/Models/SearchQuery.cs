using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;


namespace Airlines_API.Models
{
    public class SearchQuery
    {
        [Required]
        public string Booking_Type { get; set; } //one_way or return

        [Required]

        public long Depart_airport_Id { get; set; }

        [Required]

        public long Arrival_airport_Id  { get; set; }

        [Required]

        public Nullable<DateTime> Departure_Time  { get; set; }


        public Nullable<DateTime> Arrival_Time { get; set; }

        [Required]

        public int adults { get; set; }

        [Required]

        public int childs { get; set; }

        [Required]

        public int infants { get; set; }

        [Required]

        public string Class_Type { get; set; }
    }
}
