using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Interfaces;

namespace elizaveta_fateeva_kt_42_22.Services
{
    public class DepartmentDisciplineService : IDepartmentDisciplineService
    {
        private readonly DepartmentDbContext _context;

        public DepartmentDisciplineService(DepartmentDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetDisciplinesByHeadSurnameAsync(string surname, CancellationToken cancellationToken)
        {
            var head = await _context.Teachers
                .FirstOrDefaultAsync(t => t.TeacherName.ToLower().Contains(surname.ToLower()), cancellationToken);

            if (head == null)
                return new List<string>();

            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.HeadOfDepartmentId == head.TeacherId, cancellationToken);

            if (department == null)
                return new List<string>();

            var teacherIds = await _context.Teachers
                .Where(t => t.DepartmentId == department.DepartmentId)
                .Select(t => t.TeacherId)
                .ToListAsync(cancellationToken);

            if (!teacherIds.Any())
                return new List<string>();

            var disciplines = await _context.StudyLoads
                .Where(sl => teacherIds.Contains(sl.TeacherId))
                .Include(sl => sl.Discipline)
                .Select(sl => sl.Discipline.DisciplineName)
                .Distinct()
                .ToListAsync(cancellationToken);

            return disciplines;
        }
    }

}
