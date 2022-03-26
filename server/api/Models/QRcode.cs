using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class QRcode
    {
        public int Id { get; set; }
        public string token { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
