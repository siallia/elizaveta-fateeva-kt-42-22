using Microsoft.AspNetCore.Mvc;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpPost("GetDisciplines")]
        public async Task<IActionResult> GetDisciplinesAsync(
            [FromBody] DisciplineFilter filter,
            CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplineService.GetDisciplinesAsync(filter, cancellationToken);
            return Ok(disciplines);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddDiscipline([FromBody] Discipline discipline, CancellationToken cancellationToken)
        {
            var result = await _disciplineService.AddDisciplineAsync(discipline, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDiscipline(int id, [FromBody] Discipline discipline, CancellationToken cancellationToken)
        {
            var result = await _disciplineService.UpdateDisciplineAsync(id, discipline, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDiscipline(int id, CancellationToken cancellationToken)
        {
            await _disciplineService.DeleteDisciplineAsync(id, cancellationToken);
            return NoContent();
        }

    }
}
