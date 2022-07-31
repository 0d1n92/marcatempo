using api.Utilitis.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace api.Model.Entity
{
    public class Role
    {
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public EnumRoles Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users{ get; set; }
    }
}
