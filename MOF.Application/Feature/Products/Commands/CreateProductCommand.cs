using AutoMapper;
using MediatR;
using MOF.Application.DOTs.Products;
using MOF.Application.Feature.Products.Validators;
using MOF.Application.IRepositories;
using MOF.Application.IRepositories.Products;
using MOF.Domain.Entities;
using FluentValidation;

namespace MOF.Application.Feature.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public ProductDto ProductDto { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProdcutDtoValidator();
            var result = validator.Validate(request.ProductDto);

            if (result.IsValid == false)
            {
                throw new ValidationException(result.Errors);
            }

            var prodcut = mapper.Map<Product>(request.ProductDto);

            await productRepository.AddProduct(prodcut);
            await unitOfWork.SaveChange(default);
            return request.ProductDto;

        }
    }
}
