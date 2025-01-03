
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entites
{
    public class Employee:BaseEntity
    {
        [Required]
        public string? CivilId { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? JobName { get; set; }
        [Required]

        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        [Required,DataType(DataType.PhoneNumber)]
        public string? TelephoneNumber { get; set; }
        [Required]
        public string? Photo { get; set; }

        public Country? Country { get; set; }
        public int CountryId { get; set; }
        public City? City { get; set; }
        public int CityId { get; set; }

        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        public Holiday? Holiday { get; set; }
        public int HolidayId { get; set; }
        public OverTime? OverTime { get; set; }
        public int OverTimeId { get; set; }

        public EmployeeReview? EmployeeReviews { get; set; }
        public int EmployeeReviewsId { get; set; }
        public Mentorship? Mentorship { get; set; }
        public int MentorShipId { get; set; }

    }
}
