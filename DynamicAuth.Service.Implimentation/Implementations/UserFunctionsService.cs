using DynamicAuth.Domain.Entites;
using DynamicAuth.Infrastructure.Base;
using DynamicAuth.Messages.Commands;
using DynamicAuth.Repository;
using DynamicAuth.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DynamicAuth.Service.Implimentation.Implementations
{
    public class UserFunctionsService : IUserFunctionsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
 

        public UserFunctionsService(UserManager<User> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
           _configuration = configuration;
        }

        public async Task Signup(SignupCommand cmd)
        {
             
            var user = new User(cmd.UserName, cmd.FirstName, cmd.LastName, cmd.Email, cmd.PhoneNumber , cmd.City , cmd.Province , cmd.DateOfBirth , cmd.NationalId);
            var result = await _userManager.CreateAsync(user, cmd.Password);

            if (!result.Succeeded)
            {

        
                throw new ManagedException(result.Errors.Select(x => x.Description));
            }
            
        }
        public async Task<string> Signin(SigninCommand cmd)
        {
            var user = await _userManager.FindByNameAsync(cmd.UserName);
            if (user is null)
                throw new ManagedException("نام کاربری یا رمز عبور اشتباه است");
            if (await _userManager.CheckPasswordAsync(user, cmd.Password) == false)
                throw new ManagedException("نام کاربری یا رمز عبور اشتباه است");
            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("userName" , user.UserName),
            new Claim("userId" , user.Id),
            new Claim("iss",_configuration["Jwt:Issuer"] ),
               new Claim( "aud" , _configuration["Jwt:Audience"] )
                    // Add additional claims as desired
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
