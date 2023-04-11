using DynamicAuth.Messages.Commands;

namespace DynamicAuth.Service.Interfaces
{
    public interface IUserFunctionsService
    {
        public Task Signup(SignupCommand cmd);
        public Task<string> Signin(SigninCommand cmd);
    }
}
