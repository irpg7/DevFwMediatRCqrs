using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Mediatr.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest
    {
        public int ProductId { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
        {
            IProductDal _productDal;

            public DeleteProductCommandHandler(IProductDal productDal)
            {
                _productDal = productDal;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var productToDelete = _productDal.Get(p => p.ProductId == request.ProductId);

                 await _productDal.DeleteAsync(productToDelete);
                return Unit.Value;
            }
        }
    }
}
