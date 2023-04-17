using DynamicAuth.Domain.Entites;
using DynamicAuth.Infrastructure.Base;
using DynamicAuth.Messages.Commands;
using DynamicAuth.Repository;
using DynamicAuth.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DynamicAuth.Service.Implimentation.Implementations
{

    public class UserFunctionsService : IUserFunctionsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;


        public UserFunctionsService(UserManager<User> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task Signup(SignupCommand cmd)
        {
            await ValidateUserCreation(cmd.NationalId, cmd.Email, cmd.PhoneNumber);
            var user = new User(cmd.UserName, cmd.FirstName, cmd.LastName, cmd.Email, cmd.PhoneNumber, cmd.City, cmd.Province, cmd.DateOfBirth, cmd.NationalId, cmd.RegionId);
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




        public async Task UpdateUser(UpdateUserCommand cmd, string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            await ValidateUserCreation(cmd.NationalId, cmd.Email, cmd.PhoneNumber);
            user.FirstName = cmd.FirstName;
            user.LastName = cmd.LastName;
            user.Email = cmd.Email;
            user.PhoneNumber = cmd.PhoneNumber;
            user.City = cmd.City;
            user.Province = cmd.Province;
            user.DateOfBirth = cmd.DateOfBirth;
            user.NationalId = cmd.NationalId;
            user.RegionId = cmd.RegionId;
            await _unitOfWork.CommitAsync();


        }
        public async Task UpdatePassword(UpdatePasswordCommand cmd , string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.ChangePasswordAsync(user, cmd.CurrentPassword, cmd.NewPassword);
        }
        private async Task ValidateUserCreation(string nationalId, string email, string PhoneNumber)
        {
            if (await _userManager.Users.AnyAsync(x => x.NationalId == nationalId))
                throw new ManagedException("کد ملی وارد شده در سامانه ثبت شده است. ");
            if (await _userManager.Users.AnyAsync(x => x.Email == email))
                throw new ManagedException("ایمیل وارد شده در سامانه ثبت شده است. ");
            if (await _userManager.Users.AnyAsync(x => x.PhoneNumber == PhoneNumber))
                throw new ManagedException("شماره موبایل وارد شده در سامانه ثبت شده است. ");
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
        private async Task EmailSender(string toEmail , string fromEmail , string subject , string body , string smtpServer , int smtpPort , string senderPassword)
        {
            MailMessage message = new MailMessage(fromEmail, toEmail, subject, body);
            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(fromEmail, senderPassword);
            await client.SendMailAsync  (message);
        }
    }
}
