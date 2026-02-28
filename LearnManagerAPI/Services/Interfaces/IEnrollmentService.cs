using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> EnrollAsync(long studentId, long courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(long studentId);
    }
}