using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MOF.Application.DOTs.Products;
using MOF.Application.Feature.Products.Validators;
using FluentValidation;
using MOF.Application.IRepositories;
using AutoMapper;
using MOF.Application.IRepositories.Products;
using MOF.Domain.Entities;

namespace MOF.Application.Feature.Products.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public ProductDto Product { get; set; } = new ProductDto();
        public int ProductId { get; set; }
    }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProdcutDtoValidator();
            var result = validator.Validate(request.Product);

            if (result.IsValid == false)
            {
                throw new ValidationException(result.Errors);
            }

            var product = await productRepository.GetProductById(request.ProductId);
            if (product == null)
            {
                throw new ValidationException($"Invalid product id: {request.ProductId}");
            }

            mapper.Map(request.Product, product);
            await unitOfWork.SaveChange(cancellationToken);

            return request.Product;
        }
    }
}
