using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class GetFlightPrice
    {
        [Key]
        public Int64 FlightId { get; set; }
        public string SeatType { get; set; }
    }
}
