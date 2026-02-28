namespace LearnManagerAPI.DTOs;

public class RegisterDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; } // optional, defaulted by service
}
