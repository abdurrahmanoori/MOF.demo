using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MOF.Application.DOTs.Products;
using MOF.Application.IRepositories;
using MOF.Application.IRepositories.Products;

namespace MOF.Application.Feature.Products.Requests
{
    public record GetProductByProductIdRequest(int productId) : IRequest<ProductDto>
    {
    }

    internal class GetProductByProductIdRequestHandler : IRequestHandler<GetProductByProductIdRequest, ProductDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;
        private readonly IProductRepository productRepository;

        public GetProductByProductIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByProductIdRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductById(request.productId);

            if (product == null)
            {
                throw new NullReferenceException("Product not found");
            }

            return mapper.Map<ProductDto>(product);

        }
    }
}
