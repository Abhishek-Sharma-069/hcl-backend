namespace LearnManagerAPI.Models;

public class Course
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long? InstructorId { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public User Instructor { get; set; }
    public List<Lesson> Lessons { get; set; } = new();
    public List<Quiz> Quizzes { get; set; } = new();
}
