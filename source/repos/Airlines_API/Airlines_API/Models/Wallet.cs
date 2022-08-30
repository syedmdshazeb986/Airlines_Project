using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airlines_API.Models
{
    public class Wallet
    {
        [Key]
        public Int64 Wallet_id { get; set; }
        public Int64 UserId { get; set; }
        public decimal Wallet_Amount { get; set; }
    }
}
