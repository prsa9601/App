using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.Role.Create
{
    internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("تایتل نقش کاربری را وارد کنید!");
        }
    }
}
