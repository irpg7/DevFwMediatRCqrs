using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<IResult>
    {
        public int ProductId { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,IResult>
        {
            IProductDal _productDal;

            public DeleteProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var productToDelete = _productDal.Get(p => p.ProductId == request.ProductId);

                 await _productDal.DeleteAsync(productToDelete);
                return new SuccessResult(Messages.ProductDeleted);
            }
        }
    }
}
