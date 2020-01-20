using Business.ValidationRules.FluentValidation;
using Core.Aspects.PostSharp.Validation;
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
    public class CreateProductCommand:IRequest<Product>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            IProductDal _productDal;

            public CreateProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            [FluentValidationAspect(typeof(ProductValidator))]
            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    ProductName = request.ProductName,
                    UnitPrice = request.UnitPrice
                };
                await _productDal.AddAsync(product);
                return product;
            }
        }
    }
}
