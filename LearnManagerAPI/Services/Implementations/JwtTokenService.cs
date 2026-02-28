using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using LearnManagerAPI.Models;
using LearnManagerAPI.Services.Interfaces;

namespace LearnManagerAPI.Services.Implementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var key = _configuration["JwtSettings:Key"] ?? "SuperSecretKeyHere";
        var issuer = _configuration["JwtSettings:Issuer"] ?? "LmsApi";
        var audience = _configuration["JwtSettings:Audience"] ?? "LmsApiUsers";
        var expiryMinutes = int.TryParse(_configuration["JwtSettings:ExpiryMinutes"], out var m) ? m : 60;

        // Key must be at least 32 bytes for HS256
        var keyBytes = Encoding.UTF8.GetBytes(key);
        if (keyBytes.Length < 32)
        {
            var padded = new byte[32];
            Buffer.BlockCopy(keyBytes, 0, padded, 0, keyBytes.Length);
            keyBytes = padded;
        }

        var signingKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role ?? "Student"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
