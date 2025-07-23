using Core.Dto;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserSpace;

namespace Business.Services;
public class AuthService : IAuthService
{
    public IUserService _service { get; set; }
    private readonly IConfiguration _configuration;

    public AuthService(IUserService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

    public async Task<string> GenerateTokenAsync(string email, string password)
    {

        var users = await _service.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }
        
        bool isValidPassword = !string.IsNullOrEmpty(user.PasswordHash); 
    
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.Name ?? string.Empty),
            new Claim(ClaimTypes.Role, user.Role ?? "User")
        };

        // Create the token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Api:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddDays(1);

        var token = new JwtSecurityToken(
            issuer: "localhost:7237",
            audience: "localhost:4201",
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Api:SecretKey"]);

        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "localhost:7237",
                ValidAudience = "localhost:4201",
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            if (principal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw new UnauthorizedAccessException("Invalid or expired token");
        }
    }
}
