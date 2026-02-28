using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
