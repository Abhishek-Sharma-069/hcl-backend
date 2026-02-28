using Microsoft.AspNetCore.Mvc;
using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.DTOs;
using LearnManagerAPI.Models;

namespace LearnManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(CourseCreateDto dto)
        {
            // stub instructor id
            var course = await _courseService.CreateCourseAsync(dto, 1);
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}