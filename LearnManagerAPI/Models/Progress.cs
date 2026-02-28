namespace LearnManagerAPI.Models;

public class Progress
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LessonId { get; set; }
    public bool Completed { get; set; }
    public int? QuizScore { get; set; }

    // navigation
    public User Student { get; set; }
    public Lesson Lesson { get; set; }
}
