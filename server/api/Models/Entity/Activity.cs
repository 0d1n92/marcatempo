using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Response
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime? Entry { get; set; }
        public DateTime? Exit { get; set; }
        public Boolean? IsPresent { get; set; }
        public int? UserId { get; set; }
        public User User{ get; set; }
        public Giustification Giustification { get; set; }
    }
}
