namespace LearnManagerAPI.Models;

public class Quiz
{
    public long Id { get; set; }
    public long? CourseId { get; set; }
    public string Title { get; set; }

    // Navigation properties
    public Course Course { get; set; }
    public List<QuizQuestion> Questions { get; set; } = new();
}
