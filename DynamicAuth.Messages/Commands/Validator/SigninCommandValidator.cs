using FluentValidation;

namespace DynamicAuth.Messages.Commands.Validator
{
    public class SigninCommandValidator : AbstractValidator<SigninCommand>
    {
        public SigninCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمیتواند خالی باشد.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("رمز عبور نمیتواند خالی باشد. ");
            
        }
    }
}
