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
            var instructorId = dto.InstructorId ?? 1;
            var course = await _courseService.CreateCourseAsync(dto, instructorId);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> Update(int id, CourseCreateDto dto)
        {
            var course = await _courseService.UpdateCourseAsync(id, dto);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}