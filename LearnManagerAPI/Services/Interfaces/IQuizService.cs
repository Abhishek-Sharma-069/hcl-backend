using LearnManagerAPI.Models;
using LearnManagerAPI.DTOs;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> CreateQuizAsync(long courseId, Quiz quiz);
        Task<Quiz> GetQuizByIdAsync(long id);
        Task<int> SubmitQuizAsync(QuizSubmitDto dto, long studentId);
    }
}