using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class UserDetails
    {
        [Key]
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
       
        public string Lastname { get; set; }
        public Nullable<DateTime> DateofBirth { get; set; }
        public string  Email{ get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
}
