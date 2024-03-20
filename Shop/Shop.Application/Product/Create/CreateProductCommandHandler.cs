using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Product.Create
{
    internal class CreateProductCommandHandler:IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IProductService _service;

        public CreateProductCommandHandler(IProductRepository repository, IProductService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.ProductAgg.Product(request.Title, request.Price);
            _repository.Add(product);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
