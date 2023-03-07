using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);
        
    }
}
