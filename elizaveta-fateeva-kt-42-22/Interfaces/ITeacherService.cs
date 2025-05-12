using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken);

        Task<Teacher> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher, CancellationToken cancellationToken);
        Task DeleteTeacherAsync(int id, CancellationToken cancellationToken);
    }
}
