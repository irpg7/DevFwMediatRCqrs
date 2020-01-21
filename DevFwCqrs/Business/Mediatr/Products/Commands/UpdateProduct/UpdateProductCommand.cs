using Business.Constants;
using Core.Utilities.Results;
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
    public class UpdateProductCommand:IRequest<IResult>
    {
        public Product ProductForUpdate { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResult>
        {
            IProductDal _productDal;

            public UpdateProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                await _productDal.UpdateAsync(request.ProductForUpdate);
                return new SuccessResult(Messages.ProductUpdated);
            }
        }
    }
}
