using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands.Validator
{
    public class RestartPaswwordCommandValidator : AbstractValidator<RestartPasswordCommand>
    {
        public RestartPaswwordCommandValidator() {
            RuleFor(x => x.UserNameOrPassword).NotEmpty().WithMessage("ایمیل یا نام کاربری نمیتواند خالی باشد. ");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("رمز جدید نمیتواند خالی باشد. ");
        }
    }
}
