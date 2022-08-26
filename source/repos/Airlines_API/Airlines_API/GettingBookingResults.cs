using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class GettingBookingResults
    {
        public long BookingId;

        public string FlightName;

        public string Booking_Type;

        public Nullable<DateTime> Return_Date;

        public string Booking_Status;

        public decimal Booking_Amount;

        public Nullable<DateTime> Booking_Date;

        public string Class_Type;

        public Nullable<DateTime> Travel_date;

        public int No_of_Passengers;
    }
}
