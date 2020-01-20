using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Queries.GetProducts
{
    public class GetProductsQuery:IRequest<IEnumerable<Product>>
    {
        class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
        {
            readonly IProductDal _productDal;

            public GetProductsQueryHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                return await _productDal.GetListAsync();
            }
        }
    }
}
