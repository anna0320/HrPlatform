using HrPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<HrSpecialist> HrSpecialists { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
