namespace elizaveta_fateeva_kt_42_22.Interfaces
{
    public interface IDepartmentDisciplineService
    {
        Task<List<string>> GetDisciplinesByHeadSurnameAsync(string surname, CancellationToken cancellationToken);

    }
}
