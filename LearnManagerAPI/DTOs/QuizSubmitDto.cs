namespace LearnManagerAPI.DTOs;

public class QuizSubmitDto
{
    public long QuizId { get; set; }
    public Dictionary<long, string> Answers { get; set; }
}
