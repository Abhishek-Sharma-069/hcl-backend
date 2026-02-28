using LearnManagerAPI.Models;
using LearnManagerAPI.DTOs;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> CreateQuizAsync(int courseId, Quiz quiz);
        Task<Quiz> GetQuizByIdAsync(int id);
        Task<int> SubmitQuizAsync(QuizSubmitDto dto, int studentId);
    }
}