using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.Models;
using LearnManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using LearnManagerAPI.DTOs;

namespace LearnManagerAPI.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _db;

        public QuizService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Quiz> CreateQuizAsync(long courseId, Quiz quiz)
        {
            quiz.CourseId = courseId;
            _db.Quizzes.Add(quiz);
            await _db.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quiz> GetQuizByIdAsync(long id)
        {
            return await _db.Quizzes.Include(q => q.Questions).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<int> SubmitQuizAsync(QuizSubmitDto dto, long studentId)
        {
            var quiz = await _db.Quizzes.Include(q => q.Questions).FirstOrDefaultAsync(q => q.Id == dto.QuizId);
            if (quiz == null) throw new Exception("Quiz not found");

            int score = 0;
            foreach (var q in quiz.Questions)
            {
                if (dto.Answers.TryGetValue(q.Id, out var ans) && ans == q.CorrectAnswer)
                {
                    score++;
                }
            }

            var progress = new Progress
            {
                StudentId = studentId,
                QuizId = dto.QuizId,
                Completed = true,
                QuizScore = score
            };
            _db.Progresses.Add(progress);
            await _db.SaveChangesAsync();
            return score;
        }
    }
}