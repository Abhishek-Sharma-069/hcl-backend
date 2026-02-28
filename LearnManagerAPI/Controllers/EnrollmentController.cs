using Microsoft.AspNetCore.Mvc;
using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.Models;

namespace LearnManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public async Task<ActionResult<Enrollment>> Enroll([FromQuery] int studentId, [FromQuery] int courseId)
        {
            var enrollment = await _enrollmentService.EnrollAsync(studentId, courseId);
            return Ok(enrollment);
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetByStudent(int studentId)
        {
            var enrollments = await _enrollmentService.GetEnrollmentsByStudentAsync(studentId);
            return Ok(enrollments);
        }
    }
}