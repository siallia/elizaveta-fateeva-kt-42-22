using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Interfaces
{
    public interface IDisciplineService
    {
        Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken);

        Task<Discipline> AddDisciplineAsync(Discipline discipline, CancellationToken cancellationToken);
        Task<Discipline> UpdateDisciplineAsync(int id, Discipline discipline, CancellationToken cancellationToken);
        Task DeleteDisciplineAsync(int id, CancellationToken cancellationToken);
    }

}
