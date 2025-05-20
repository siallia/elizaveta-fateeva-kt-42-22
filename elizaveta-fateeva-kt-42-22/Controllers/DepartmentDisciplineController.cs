using Microsoft.AspNetCore.Mvc;
using elizaveta_fateeva_kt_42_22.Interfaces;

namespace elizaveta_fateeva_kt_42_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentDisciplineController : ControllerBase
    {
        private readonly IDepartmentDisciplineService _service;

        public DepartmentDisciplineController(IDepartmentDisciplineService service)
        {
            _service = service;
        }

        [HttpGet("ByHeadSurname")]
        public async Task<IActionResult> GetDisciplinesByHeadSurname(
            [FromQuery] string surname,
            CancellationToken cancellationToken)
        {
            var disciplines = await _service.GetDisciplinesByHeadSurnameAsync(surname, cancellationToken);

            if (!disciplines.Any())
                return NotFound($"По заведующему с фамилией '{surname}' дисциплины не найдены.");

            return Ok(disciplines);
        }
    }

}
