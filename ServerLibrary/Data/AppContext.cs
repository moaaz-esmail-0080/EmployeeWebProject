 
using BaseLibrary.Entites;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{

        public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
        {
        public DbSet<Employee> Employees { get; set; }

         //Department /Branch
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

          //Country / City /Town 
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        // Authentication /Role /SystemRole /UserRole /RfreshToken
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }


        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<OverTime> OverTimes { get; set; }
        public DbSet<EmployeeReview> EmployeeReviews { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }

    }
    
}
