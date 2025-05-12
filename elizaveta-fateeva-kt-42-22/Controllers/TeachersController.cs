using Microsoft.AspNetCore.Mvc;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachers")]
        public async Task<IActionResult> GetTeachersAsync(
            [FromBody] TeacherFilter filter,
            CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersAsync(filter, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher, CancellationToken cancellationToken)
        {
            var result = await _teacherService.AddTeacherAsync(teacher, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher, CancellationToken cancellationToken)
        {
            var result = await _teacherService.UpdateTeacherAsync(id, teacher, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id, CancellationToken cancellationToken)
        {
            await _teacherService.DeleteTeacherAsync(id, cancellationToken);
            return NoContent();
        }

    }
}
