using Application.Dto;
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

        [SwaggerOperation(Summary = "Create a new course")]
        [HttpPost]
        public IActionResult Create(CreateCourseDto newCourse)
        {
            var course = _courseService.AddNewCourse(newCourse);
            return Created($"api/courses/{course.Id}", course);
        }

        [SwaggerOperation(Summary = "Update an existing course")]
        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourse)
        {
            _courseService.UpdateCourse(updateCourse);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific course")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return NoContent();
        }

    }
}
