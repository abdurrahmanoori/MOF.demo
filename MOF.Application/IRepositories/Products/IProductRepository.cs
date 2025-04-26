using MOF.Application.DOTs.Products;
using MOF.Domain.Entities;

namespace MOF.Application.IRepositories.Products
{
    public interface IProductRepository
    {
       public Task<Product> GetProductById(int id);

        public Task<Product> AddProduct(Product product);

        public Task<IList<Product>> GetAllProducts();

        public void RemoveProduct (Product product);

    }
}
