using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MOF.Application.IRepositories;
using MOF.Application.IRepositories.Products;
using FluentValidation;
using AutoMapper;
using MOF.Domain.Entities;

namespace MOF.Application.Feature.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
    }

    internal class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public DeleteProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductById(request.ProductId);
            if (product == null)
            {
                throw new ValidationException($"product with id {request.ProductId} not found");
            }

             productRepository.RemoveProduct(product);
            await unitOfWork.SaveChange(cancellationToken);
            return Unit.Value;
        }
    }
}
