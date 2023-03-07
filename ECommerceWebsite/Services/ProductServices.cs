using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;

namespace ECommerceWebsite.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository repo;
        public ProductServices(IProductRepository repo)
        {
            this.repo = repo;
        }

        public int AddProduct(Product product)
        {
            return repo.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return repo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public int UpdateProduct(Product product)
        {
            return repo.UpdateProduct(product);
        }
    }
}
