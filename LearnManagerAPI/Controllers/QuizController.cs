using Microsoft.AspNetCore.Mvc;
using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.Models;
using LearnManagerAPI.DTOs;

namespace LearnManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public async Task<ActionResult<Quiz>> Create([FromQuery] int courseId, Quiz quiz)
        {
            var result = await _quizService.CreateQuizAsync(courseId, quiz);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> Get(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<int>> Submit(QuizSubmitDto dto)
        {
            var score = await _quizService.SubmitQuizAsync(dto, 1);
            return Ok(score);
        }
    }
}