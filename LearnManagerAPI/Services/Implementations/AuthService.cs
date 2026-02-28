using LearnManagerAPI.Services.Interfaces;
using LearnManagerAPI.DTOs;
using LearnManagerAPI.Models;
using LearnManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnManagerAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;

        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            // make sure email is unique
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
            {
                // conflict – caller will translate
                throw new InvalidOperationException("Email already registered");
            }

            var user = new User
            {
                Name = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.Password, // TODO: hash
                Role = "Student",
                CreatedAt = DateTime.UtcNow
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                // not found – indicate failure to controller
                return null;
            }
            // TODO: verify password; return null if incorrect

            return "token";
        }
    }
}