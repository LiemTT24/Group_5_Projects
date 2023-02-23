using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Group5_API_Project.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Group5_API_Project.Controllers
{
    /// <summary>
    /// Route >> set url for api account
    /// </summary>
    [Route("api/accounts/[Action]")]
    [ApiController]
    public class AccountControllers : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public AccountControllers(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpModel)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(signUpModel.Password);
            var account = new Account
            {
                Email = signUpModel.Email,
                Password = passwordHash,
                FullName = signUpModel.FullName,
                PhoneNumber = signUpModel.PhoneNumber,
                Address = signUpModel.Address
            };
            _dbcontext.Accounts.Add(account);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountDTO signInModel)
        {
            var user = await _dbcontext.Accounts.FirstOrDefaultAsync(u => u.Email == signInModel.Email);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(signInModel.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            if (!BCrypt.Net.BCrypt.Verify(signInModel.Password, user.Password))
            {
                return Unauthorized();
            }
            var token = CreateToken(user);
            return Ok(new { token });

        }
        private string CreateToken(Account user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AppSettings:Token"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
