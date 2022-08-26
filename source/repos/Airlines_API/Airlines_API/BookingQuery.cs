using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    [Keyless]
    public class BookingQuery
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long FlightId { get; set; }

        [Required]
        public string Booking_Type { get; set; }

        [Required]
        public Nullable<DateTime> Return_Date { get; set; }

        [Required]
        public string Class_Type { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Travel_date { get; set; }

        [Required]
        public string Payment_mode { get; set; }


        [Required]
        public List<Passenger> Passengers { get; set; }
    }
}
