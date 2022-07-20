using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.Entity
{
    public class QRcode
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid token { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
