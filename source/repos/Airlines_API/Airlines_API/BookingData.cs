using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{

    public class BookingData
    {
        [Key]
        [Required]
        public long BookingId { get; set; }

        [Required]
        public long FlightId { get; set; }
    }
}
