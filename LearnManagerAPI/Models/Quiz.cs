namespace LearnManagerAPI.Models;

public class Quiz
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; }

    // navigation
    public Course Course { get; set; }
    public List<QuizQuestion> Questions { get; set; }
}
