using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.DTOs;
using LearnManagerAPI.Models;
using LearnManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnManagerAPI.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _db;

        public CourseService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Course> CreateCourseAsync(CourseCreateDto dto, long instructorId)
        {
            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                InstructorId = instructorId,
                CreatedAt = DateTime.UtcNow
            };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _db.Courses.Include(c => c.Instructor).ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(long id)
        {
            return await _db.Courses.Include(c => c.Lessons).Include(c => c.Quizzes).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}