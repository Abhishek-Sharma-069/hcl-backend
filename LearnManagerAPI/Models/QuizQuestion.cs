namespace LearnManagerAPI.Models;

public class QuizQuestion
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }

    // navigation
    public Quiz Quiz { get; set; }
}
