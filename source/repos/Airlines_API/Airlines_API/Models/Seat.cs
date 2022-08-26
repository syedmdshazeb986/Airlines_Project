using System.ComponentModel.DataAnnotations;

namespace WebAPI_Airlines.Models
{
    public class Seat
    {

        [Key]
        [Required]
        public long SeatId { get; set; }

        [Required]
        public string SeatName{ get; set; }
         [Required]
        public long FlightId { get; set; }

        [Required]
        public int Row_no { get; set; }

        [Required]
        public int Col_no { get; set; }

        [Required]
        public string SeatType { get; set; }

        [Required]
        public bool is_booked { get; set; }
    }
}
