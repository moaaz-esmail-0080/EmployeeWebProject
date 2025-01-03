
using System.Text.Json.Serialization;

namespace BaseLibrary.Entites
{
    public class Branch : BaseEntity
    {
        public Department? Department { get; set; } 

        public int DepatrmenId { get; set; }

        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }
    }
}
