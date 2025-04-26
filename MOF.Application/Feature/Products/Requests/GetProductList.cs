using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MOF.Application.DOTs.Products;
using MOF.Application.IRepositories.Products;

namespace MOF.Application.Feature.Products.Requests
{
    public class GetProductList : IRequest<IList<ProductDto>>
    {
    }


    internal class GetProductListHadler : IRequestHandler<GetProductList, IList<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductListHadler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ProductDto>> Handle(GetProductList request, CancellationToken cancellationToken)
        {
            var list = await productRepository.GetAllProducts();

            return mapper.Map<IList<ProductDto>>(list);
        }
    }
}
