using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.User.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("نام کاربری را وارد کنید!");
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("پسوورد را وارد کنید!");
            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(11)
                .MinimumLength(11)
                .WithMessage("شماره تلفن باید 11 کاراکتر باشد.");
        }
    }
}
