using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Controllers
{
    [Route("API/")]
    [ApiController]
    public class AuthController : Controller
    {
        public static User user = new User();
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserLogin request)
        {
            user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.Login = request.Login;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            try
            {
                using (AppDbContext dbContext = new AppDbContext())
                {
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                }

                return Ok("Register Complited!");
            }
            catch(Exception ex)
            {
                return BadRequest("Exeption:" + ex);
            }            
        }

        [HttpPost("logIn")]
        public async Task<ActionResult<string>> LogIn(UserLogin request)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                if ((user = dbContext.Users.FirstOrDefault(u => u.Login == request.Login)) == null)
                    return BadRequest("User not found");

                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    return BadRequest("Wrong password");

                string token = CreateToken(user);
                return Ok(token);

            }
        
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Login),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);  

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        { 
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
