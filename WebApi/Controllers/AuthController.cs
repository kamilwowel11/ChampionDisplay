using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DTO;
using WebApi.Infrastructure.Context;
using WebApi.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
            private readonly IAuthRepository _repository;
            private readonly IConfiguration _configuration;

            public AuthController(IAuthRepository repository, IConfiguration configuration)
            {
                _repository = repository;
                _configuration = configuration;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(UserToRegisterDto userToRegisterDto)
            {
                userToRegisterDto.Login = userToRegisterDto.Login.ToLower();

                if (await _repository.UserExists(userToRegisterDto.Login)){
                    return BadRequest("Użytkownik już istnieje!");
                }

                var userToCreate = new UserEntity {
                    Login = userToRegisterDto.Login, IsAdmin = false };
                    await _repository.Register(userToCreate, userToRegisterDto.Password);

                    return StatusCode(201);
            }

          

            [HttpPost("Login")]
            public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
            {
                //Getting user data
                var userFromRepository = await _repository.Login(userForLoginDto.Login, userForLoginDto.Password);
                 if (userFromRepository == null){
                     //Console.WriteLine("Nie autoryzowany");
                     return Unauthorized();
                 }
                // what role he/she will get
                var userRole = userFromRepository.IsAdmin ? Roles.Admin : Roles.Casual;

                //getting all information grouped 

                var credentialsClaims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepository.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepository.Login),
                    new Claim(ClaimTypes.Role, userRole)
                };
                //How token Should be authorized
                var credentialsKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
                var credentials = new SigningCredentials(credentialsKey, SecurityAlgorithms.HmacSha512Signature);   

                var tokenConfiguration = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(credentialsClaims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();  
                var token = tokenHandler.CreateToken(tokenConfiguration);
                //Console.WriteLine(token);

                return Ok(new {
                    token = tokenHandler.WriteToken(token)
                });
            }

    }
}