using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        int AddProduct (Product product);
        int UpdateProduct (Product product);
        int DeleteProduct (int id);
    }
}
