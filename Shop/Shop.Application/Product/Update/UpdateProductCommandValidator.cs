using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.Product.Update
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("نام محصول را وارد کنید!");
            RuleFor(r => r.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("قیمت محصول را وارد کنید!");
        }
    }
}
