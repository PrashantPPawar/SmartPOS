using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POS.API.DTOs;
using POS.API.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public AuthController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _repo.Login(dto.UserName, dto.Password);

            if (user == null)
                return Unauthorized();

            var token = GenerateJwt(user.UserName);

            return Ok(new { token });
        }

        private string GenerateJwt(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-POS-2026-Starting-New-Project"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
