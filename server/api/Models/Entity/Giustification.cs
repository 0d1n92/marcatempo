using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.Entity
{
    public class Giustification
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        public DateTime Duration { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
