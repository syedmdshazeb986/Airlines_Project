using System.ComponentModel.DataAnnotations;

namespace Airlines_API.Models
{
    public class Airport
    {
        [Key]
        [Required]
        public long AirportId { get; set; }

        [Required]
        public string AirportName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

    }
}
