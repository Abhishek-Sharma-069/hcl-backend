using LearnManagerAPI.DTOs;
using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDto dto);
        Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    }
}