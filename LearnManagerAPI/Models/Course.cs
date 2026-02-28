namespace LearnManagerAPI.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int InstructorId { get; set; }
    public DateTime CreatedAt { get; set; }

    // navigation
    public User Instructor { get; set; }
    public List<Lesson> Lessons { get; set; }
    public List<Quiz> Quizzes { get; set; }
}
