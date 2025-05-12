using Microsoft.AspNetCore.Mvc;
using elizaveta_fateeva_kt_42_22.Filters;
using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudyLoadsController : ControllerBase
    {
        private readonly IStudyLoadService _studyLoadService;

        public StudyLoadsController(IStudyLoadService studyLoadService)
        {
            _studyLoadService = studyLoadService;
        }

        [HttpPost("GetStudyLoads")]
        public async Task<IActionResult> GetStudyLoadsAsync(
            [FromBody] StudyLoadFilter filter,
            CancellationToken cancellationToken = default)
        {
            var studyLoads = await _studyLoadService.GetStudyLoadsAsync(filter, cancellationToken);
            return Ok(studyLoads);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStudyLoad([FromBody] StudyLoad load, CancellationToken cancellationToken)
        {
            var result = await _studyLoadService.AddStudyLoadAsync(load, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudyLoad(int id, [FromBody] StudyLoad load, CancellationToken cancellationToken)
        {
            var result = await _studyLoadService.UpdateStudyLoadAsync(id, load, cancellationToken);
            return Ok(result);
        }

    }

}
