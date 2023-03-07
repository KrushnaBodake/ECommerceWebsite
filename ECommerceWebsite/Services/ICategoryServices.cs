using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);
    }
}
