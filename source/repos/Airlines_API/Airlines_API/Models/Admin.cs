using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class Admin
    {
        [Key]
        public long AdminId { get; set; }

        public string AdminName { get; set; }
        public string Admin_Username { get; set; }
        public string Admin_password { get; set; }
    }
}
