using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MOF.Application.DOTs.Products;

namespace MOF.Application.Feature.Products.Validators
{
    public class ProdcutDtoValidator : AbstractValidator<ProductDto>
    {
        public ProdcutDtoValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty();

            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}
