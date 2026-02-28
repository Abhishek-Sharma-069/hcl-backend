namespace LearnManagerAPI.DTOs;

public class QuizSubmitDto
{
    public int QuizId { get; set; }
    public Dictionary<int, string> Answers { get; set; }
}
