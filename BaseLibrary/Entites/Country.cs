﻿

using System.Text.Json.Serialization;

namespace BaseLibrary.Entites
{
    public class Country:BaseEntity
    {
        // One to many relationship with City
        [JsonIgnore]
        public List<City>? Cities {  get; set; } 
    }
}
