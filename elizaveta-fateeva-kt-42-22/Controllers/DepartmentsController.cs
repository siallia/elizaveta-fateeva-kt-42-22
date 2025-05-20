using Microsoft.AspNetCore.Mvc;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost(Name = "GetDepartments")]
        public async Task<IActionResult> GetDepartmentsAsync(DepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var departments = await _departmentService.GetDepartmentsAsync(filter, cancellationToken);
            return Ok(departments);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddDepartment([FromBody] Department department, CancellationToken cancellationToken)
        {
            var result = await _departmentService.AddDepartmentAsync(department, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department, CancellationToken cancellationToken)
        {
            var result = await _departmentService.UpdateDepartmentAsync(id, department, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id, CancellationToken cancellationToken)
        {
            await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
            return NoContent();
        }

    }


}
