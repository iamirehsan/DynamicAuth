using DynamicAuth.Messages.Commands;

namespace DynamicAuth.Service.Interfaces
{
    public interface IUserFunctionsService
    {
        public Task Signup(SignupCommand cmd);
        public Task<string> Signin(SigninCommand cmd);

        public Task UpdateUser(UpdateUserCommand cmd , string userId);

        public Task UpdatePassword(UpdatePasswordCommand cmd , string userId);

        public Task<string> SendOTPByEmailForForgetPassword(string UserNameOrEmial);

        public Task ValidateOTP(ValidteOTPCommand cmd);
        public Task RestartPassword(RestartPasswordCommand cmd);
    }
}
