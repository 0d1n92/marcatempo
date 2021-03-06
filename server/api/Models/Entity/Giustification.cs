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
        public string note { get; set; }
        public string code { get; set; }
        public DateTime Duration { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public ICollection<Action> Activitis { get; set; }
    }
}
