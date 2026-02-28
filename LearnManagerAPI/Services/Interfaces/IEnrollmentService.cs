using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> EnrollAsync(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId);
    }
}