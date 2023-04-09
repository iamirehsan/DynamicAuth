using FluentValidation;

namespace DynamicAuth.Messages.Commands.Validator
{
    public class SignupCommandValidator : AbstractValidator<SignupCommand>
    {
        public SignupCommandValidator()
        {
            
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمیتواند خالی باشد.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("نام کاربر نمیتواند خالی باشد");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("نام خانوادگی کارربر نمیتواند خالی باشد");
            RuleFor(x => x.Password).NotEmpty().WithMessage("رمز عبور کارربر نمیتواند خالی باشد");
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now).WithMessage("تاریخ تولد باید کمتر از تاریخ حال باشد. ");


             

        }
    }
}
