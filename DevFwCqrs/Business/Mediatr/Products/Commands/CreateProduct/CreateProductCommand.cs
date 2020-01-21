using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.PostSharp.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<IResult>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResult>
        {
            IProductDal _productDal;

            public CreateProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            [FluentValidationAspect(typeof(ProductValidator))]
            public async Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice
                };
                await _productDal.AddAsync(product);
                return new SuccessResult(Messages.ProductAdded);
            }
        }
    }
}
