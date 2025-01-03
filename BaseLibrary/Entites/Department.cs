

using System.Text.Json.Serialization;

namespace BaseLibrary.Entites
{
    public class Department:BaseEntity
    {
        public int GeneralDepartmentId { get; set; }

        //One to many relationship with Branch
        [JsonIgnore]
        public List<Branch>?  Branches { get; set; }
    }
}
