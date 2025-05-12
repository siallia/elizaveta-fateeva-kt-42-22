using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Services
{
    public class StudyLoadService : IStudyLoadService
    {
        private readonly DepartmentDbContext _dbContext;

        public StudyLoadService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudyLoad[]> GetStudyLoadsAsync(StudyLoadFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.StudyLoads
                .Include(sl => sl.Teacher)
                    .ThenInclude(t => t.Department)
                .Include(sl => sl.Discipline)
                .AsQueryable();

            if (filter.TeacherId.HasValue)
                query = query.Where(sl => sl.TeacherId == filter.TeacherId.Value);

            if (filter.DepartmentId.HasValue)
                query = query.Where(sl => sl.Teacher.DepartmentId == filter.DepartmentId.Value);

            if (filter.DisciplineId.HasValue)
                query = query.Where(sl => sl.DisciplineId == filter.DisciplineId.Value);

            return await query.ToArrayAsync(cancellationToken);
        }

        public async Task<StudyLoad> AddStudyLoadAsync(StudyLoad load, CancellationToken cancellationToken)
        {
            _dbContext.StudyLoads.Add(load);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return load;
        }

        public async Task<StudyLoad> UpdateStudyLoadAsync(int id, StudyLoad updated, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.StudyLoads.FindAsync(new object[] { id }, cancellationToken);
            if (existing == null)
                throw new InvalidOperationException("StudyLoad not found");

            existing.TeacherId = updated.TeacherId;
            existing.DisciplineId = updated.DisciplineId;
            existing.hours = updated.hours;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existing;
        }

    }

}
