using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands.Validator
{
    public class ValidteOTPAndChangePasswordCommandValidator : AbstractValidator<ValidteOTPAndChangePasswordCommand>

    {
        public ValidteOTPAndChangePasswordCommandValidator()
        {
            RuleFor(x => x.OTP).NotEmpty().WithMessage("کد یک بار مصرف نمیتواند خالی باشد");
            RuleFor(x => x.OTPKey).NotEmpty().WithMessage("ایدی کد یک بار مصرف نمیتواند خالی باشد. ");
            RuleFor(x => x.UserNameOrPassword).NotEmpty().WithMessage("ایمیل یا نام کاربری نمیتواند خالی باشد. ");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("رمز جدید نمیتواند خالی باشد. ");

        }
    }

}
