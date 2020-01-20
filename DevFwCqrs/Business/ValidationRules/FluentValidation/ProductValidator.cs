using Business.Mediatr.Products.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<CreateProductCommand>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(3);
        }
    }
}
