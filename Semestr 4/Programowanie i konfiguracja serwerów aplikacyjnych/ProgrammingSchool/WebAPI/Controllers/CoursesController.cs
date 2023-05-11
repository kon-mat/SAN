using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [SwaggerOperation(Summary = "Retrieves all courses")]
        [HttpGet]
        public IActionResult Get()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [SwaggerOperation(Summary = "Retrieves a specific post by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) 
            {
                return NotFound();
            }

            return Ok(course);
        }

    }
}
