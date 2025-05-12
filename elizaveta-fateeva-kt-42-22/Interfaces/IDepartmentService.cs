using Microsoft.EntityFrameworkCore;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Interfaces
{
    public interface IDepartmentService
{
    Task<Department[]> GetDepartmentsAsync(DepartmentFilter filter, CancellationToken cancellationToken);

    Task<Department> AddDepartmentAsync(Department department, CancellationToken cancellationToken);
    Task<Department> UpdateDepartmentAsync(int id, Department department, CancellationToken cancellationToken);
    Task DeleteDepartmentAsync(int id, CancellationToken cancellationToken);
}



   

}
