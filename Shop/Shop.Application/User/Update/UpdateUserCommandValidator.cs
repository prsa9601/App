using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.User.Update
{
    internal class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(r => r.userName)
                .NotEmpty()
                .NotNull()
                .WithMessage("نام کاربری را وارد کنید!");
            RuleFor(r => r.password)
                .NotEmpty()
                .NotNull()
                .WithMessage("پسوورد را وارد کنید!");
            RuleFor(r => r.phoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("شماره تلفن باید 11 کاراکتر باشد.");
        }
    }
}
