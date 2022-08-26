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
    }
}
