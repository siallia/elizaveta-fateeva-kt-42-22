using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database.Configuration;
using elizaveta_fateeva_kt_42_22.Models;
namespace elizaveta_fateeva_kt_42_22.Database
{

    public class DepartmentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudyLoad> StudyLoads { get; set; }

        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new StudyLoadConfiguration());
        }
    }
}
