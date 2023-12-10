using Business.Abstracts;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _instructorService.GetListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            await _instructorService.AddAsync(createInstructorRequest);
            return Ok();
        }
    }
}
