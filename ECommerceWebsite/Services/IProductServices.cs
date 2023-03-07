using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
    }
}
