using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAuth.Messages.Commands.Validator
{
    internal class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کاربری نمیتواند خالی باشد.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("رمز عبور نمیتواند خالی باشد. ");

        }
    }
}
