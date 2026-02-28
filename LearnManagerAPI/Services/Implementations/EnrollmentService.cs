using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.Models;
using LearnManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnManagerAPI.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly ApplicationDbContext _db;

        public EnrollmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Enrollment> EnrollAsync(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.UtcNow
            };
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
            return enrollment;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentAsync(int studentId)
        {
            return await _db.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();
        }
    }
}