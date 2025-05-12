using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentDbContext _dbContext;

        public DepartmentService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department[]> GetDepartmentsAsync(DepartmentFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Departments
                .Include(d => d.HeadOfDepartment)
                .AsQueryable();

            if (filter.Year.HasValue)
            {
                query = query.Where(d => d.Year == filter.Year.Value);
            }

            var departmentsWithCounts = await query
                .Select(d => new
                {
                    Department = d,
                    TeacherCount = _dbContext.Teachers.Count(t => t.DepartmentId == d.DepartmentId)
                })
                .ToListAsync(cancellationToken);

            if (filter.TeacherCount.HasValue)
            {
                departmentsWithCounts = departmentsWithCounts
                    .Where(x => x.TeacherCount == filter.TeacherCount.Value)
                    .ToList();
            }

            return departmentsWithCounts
                .Select(x => x.Department)
                .ToArray();
        }

        public async Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken)
        {
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(int id, Department updated, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Departments.FindAsync(new object[] { id }, cancellationToken);
            if (existing == null)
                throw new InvalidOperationException("Department not found");

            existing.DepartmentName = updated.DepartmentName;
            existing.Year = updated.Year;
            existing.HeadOfDepartmentId = updated.HeadOfDepartmentId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken)
        {
            var department = await _dbContext.Departments
                .Include(d => d.HeadOfDepartment)
                .FirstOrDefaultAsync(d => d.DepartmentId == id, cancellationToken);

            if (department == null)
                return;

            var teachers = _dbContext.Teachers.Where(t => t.DepartmentId == id);
            _dbContext.Teachers.RemoveRange(teachers);
            _dbContext.Departments.Remove(department);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
