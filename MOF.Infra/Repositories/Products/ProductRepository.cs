using Microsoft.EntityFrameworkCore;
using MOF.Application.DOTs.Products;
using MOF.Application.IRepositories.Products;
using MOF.Domain.Entities;
using MOF.Infra.Data;

namespace MOF.Infra.Repositories.Products
{
    internal class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result =  await context.Products.AddAsync(product);
            return result.Entity;

        }

        public async Task<IList<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id)!;
        }

        public void RemoveProduct(Product product)
        {
             context.Products.Remove(product);
        }
    }
}
