using LearnManagerAPI.Models;
using LearnManagerAPI.DTOs;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CourseCreateDto dto, int instructorId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
    }
}