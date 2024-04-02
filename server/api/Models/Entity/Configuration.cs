
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api.Model.Entity
{
    [Index(nameof(Configuration.MetaName), IsUnique = true)]
    public class Configuration
    {
        public int Id { get; set; }
        public string MetaName { get; set; }
        public string Description { get; set; }
        public JObject Value { get; set; }
        public string Category { get; set; }
    }
}
