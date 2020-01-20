using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<Product>
    {
        public Product ProductForUpdate { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
        {
            IProductDal _productDal;

            public UpdateProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productDal.UpdateAsync(request.ProductForUpdate);
                return request.ProductForUpdate;
            }
        }
    }
}
