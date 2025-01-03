
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entites
{
    public class OverTime:  BaseId
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days;
        

    }
}
