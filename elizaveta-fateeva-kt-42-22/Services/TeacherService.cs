using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly DepartmentDbContext _dbContext;

        public TeacherService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.Teachers
                .Include(t => t.Department)
                .Include(t => t.Degree)
                .Include(t => t.Position)
                .AsQueryable();

            if (filter.DepartmentId.HasValue)
                query = query.Where(t => t.DepartmentId == filter.DepartmentId.Value);

            if (filter.DegreeId.HasValue)
                query = query.Where(t => t.DegreeId == filter.DegreeId.Value);

            if (filter.PositionId.HasValue)
                query = query.Where(t => t.PositionId == filter.PositionId.Value);

            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken)
        {
            _dbContext.Teachers.Add(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return teacher;
        }

        public async Task<Teacher> UpdateTeacherAsync(int id, Teacher updated, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Teachers.FindAsync(new object[] { id }, cancellationToken);
            if (existing == null)
                throw new InvalidOperationException("Teacher not found");

            existing.TeacherName = updated.TeacherName;
            existing.DepartmentId = updated.DepartmentId;
            existing.PositionId = updated.PositionId;
            existing.DegreeId = updated.DegreeId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task DeleteTeacherAsync(int id, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(new object[] { id }, cancellationToken);
            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }

}
