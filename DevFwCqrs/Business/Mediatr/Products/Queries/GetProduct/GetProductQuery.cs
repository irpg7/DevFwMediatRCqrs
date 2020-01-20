using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Queries.GetProduct
{
    public class GetProductQuery:IRequest<Product>
    {
        public int ProductId { get; set; }

        class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
        {
            IProductDal _productDal;

            public GetProductQueryHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productDal.GetAsync(p => p.ProductId == request.ProductId);
                return product;
            }
        }
    }
}
