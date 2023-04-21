using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands.Validator
{
    public class ValidteOTPCommandValidator : AbstractValidator<ValidteOTPCommand>

    {
        public ValidteOTPCommandValidator()
        {
            RuleFor(x => x.OTP).NotEmpty().WithMessage("کد یک بار مصرف نمیتواند خالی باشد");
            RuleFor(x => x.OTPKey).NotEmpty().WithMessage("ایدی کد یک بار مصرف نمیتواند خالی باشد. ");
          

        }
    }

}
