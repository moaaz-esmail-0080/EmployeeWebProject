

using System.Text.Json.Serialization;

namespace BaseLibrary.Entites
{
    public class City:BaseEntity
    {
        //Many to one relationship with country
          public Country? Country { get; set; }
          public int CountryId { get; set; }



    }
}
