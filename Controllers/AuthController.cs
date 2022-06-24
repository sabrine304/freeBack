
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Education.Models;
using crudProjectWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace crudProjectWebApi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DbContextApplication _context;

        public AuthController(DbContextApplication context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel userLogin)
        {
            
                var user = await Authenticate(userLogin);
               
                    var token = GenerateToken(user);
                    return Ok(token);
              
        }
        private string GenerateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //start code for role
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleCode)
                };
            //end code for role
            var token = new JwtSecurityToken(
                  
                   issuer: "https://localhost:44308/",
                   audience: "https://localhost:44308/",
                   claims: claims, // claims: new List<Claim>()
                   expires: DateTime.Now.AddMinutes(20),
                   signingCredentials: signingCredentials
                   );
            return new JwtSecurityTokenHandler().WriteToken(token);
            //return Ok(new AuthenticatedResponse { Token = tokenString });

        }

        [HttpPost]
        public async Task<User> Authenticate(LoginModel User)
        {
            //var cryptedPassword = BCrypt.Net.BCrypt.HashPassword(User.Password);
            try
            {
                List<User> users = new List<User>();
                users = await _context.User.ToListAsync();
                User user = users.Find(u => u.UserName == User.UserName);
                bool verify = BCrypt.Net.BCrypt.Verify(User.Password, user.Password);
                if(verify)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 

           


    }
}
