using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class GetBookings
    {
        [Key]
        public Int64 BookingId { get; set; }
        public string FlightName { get; set; }
        public string Source_City { get; set; }

        public string Destination_City { get; set; }

        public Nullable<DateTime> Departure_time { get; set; }

        public Nullable<DateTime> Arrival_time { get; set; }

        public string Booking_Type { get; set; }
        public Nullable<DateTime> Return_Date { get; set; }
        public string Booking_Status { get; set; }
        public Decimal Booking_Amount { get; set; }
        public Nullable<DateTime> Booking_date { get; set; }
        public string Class_Type { get; set; }
        public Nullable<DateTime> Travel_date { get; set; }
        public int No_of_Passengers { get; set; }
        public Nullable<DateTime> Cancellation_Time { get; set; }

    }
}

