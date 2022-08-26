using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirLines_API.Models
{



    [Keyless]
    public class SearchData
    {
           
       



            public long FlightId { get; set; }


            public string source_city { get; set; }

            public string destination_city { get; set; }

            public string FlightName { get; set; }


            public DateTime Departure_Time { get; set; }

            public DateTime Arrival_Time{ get; set; }

        
    }
}
