using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;

namespace ECommerceWebsite.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository repo;
        public CategoryServices(ICategoryRepository repo)
        {
                this.repo = repo;
        }

        public int AddCategory(Category cat)
        {
            return repo.AddCategory(cat);
        }

        public int DeleteCategory(int id)
        {
            return repo.DeleteCategory(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);
        }

        public int UpdateCategory(Category cat)
        {
            return repo.UpdateCategory(cat);
        }
    }
}
