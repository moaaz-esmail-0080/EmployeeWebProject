

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entites
{
    public class Holiday:BaseId
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);
     
    }
}
