using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly DepartmentDbContext _dbContext;

        public DisciplineService(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken)
        {
            var query = _dbContext.StudyLoads
                .Include(sl => sl.Discipline)
                .AsQueryable();

            if (filter.TeacherId.HasValue)
                query = query.Where(sl => sl.TeacherId == filter.TeacherId.Value);

            if (filter.MinHours.HasValue)
                query = query.Where(sl => sl.hours >= filter.MinHours.Value);

            if (filter.MaxHours.HasValue)
                query = query.Where(sl => sl.hours <= filter.MaxHours.Value);

            return await query
                .Select(sl => sl.Discipline)
                .Distinct()
                .ToArrayAsync(cancellationToken);
        }


        public async Task<Discipline> AddDisciplineAsync(Discipline discipline, CancellationToken cancellationToken)
        {
            _dbContext.Disciplines.Add(discipline);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return discipline;
        }

        public async Task<Discipline> UpdateDisciplineAsync(int id, Discipline updated, CancellationToken cancellationToken)
        {
            var existing = await _dbContext.Disciplines.FindAsync(new object[] { id }, cancellationToken);
            if (existing == null)
                throw new InvalidOperationException("Discipline not found");

            existing.DisciplineName = updated.DisciplineName;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existing;
        }

        public async Task DeleteDisciplineAsync(int id, CancellationToken cancellationToken)
        {
            var discipline = await _dbContext.Disciplines.FindAsync(new object[] { id }, cancellationToken);
            if (discipline != null)
            {
                _dbContext.Disciplines.Remove(discipline);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

    }

}
