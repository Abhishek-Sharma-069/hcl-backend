namespace LearnManagerAPI.Models;

public class Progress
{
    public long Id { get; set; }
    public long? StudentId { get; set; }
    public long? LessonId { get; set; }
    public long? QuizId { get; set; }
    public bool Completed { get; set; }
    public int? QuizScore { get; set; }

    // Navigation properties
    public User Student { get; set; }
    public Lesson Lesson { get; set; }
    public Quiz Quiz { get; set; }
}
