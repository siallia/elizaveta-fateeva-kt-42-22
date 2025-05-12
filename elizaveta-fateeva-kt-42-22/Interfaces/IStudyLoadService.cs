using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Interfaces
{
    public interface IStudyLoadService
    {
        Task<StudyLoad[]> GetStudyLoadsAsync(StudyLoadFilter filter, CancellationToken cancellationToken);

        Task<StudyLoad> AddStudyLoadAsync(StudyLoad load, CancellationToken cancellationToken);
        Task<StudyLoad> UpdateStudyLoadAsync(int id, StudyLoad load, CancellationToken cancellationToken);
    }

}
