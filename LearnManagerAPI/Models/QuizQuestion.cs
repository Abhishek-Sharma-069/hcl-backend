namespace LearnManagerAPI.Models;

public class QuizQuestion
{
    public long Id { get; set; }
    public long? QuizId { get; set; }
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }

    // Navigation properties
    public Quiz Quiz { get; set; }
}
