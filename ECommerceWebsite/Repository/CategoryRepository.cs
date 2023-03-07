using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCategory(Category cat)
        {
            int result = 0;
            db.Categories.Add(cat);
            result= db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            var cat= db.Categories.Where(x => x.Catid == id).FirstOrDefault();
            if(cat != null)
            {
                db.Categories.Remove(cat);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var cat= db.Categories.Where(x=>x.Catid == id).FirstOrDefault();
            return cat;
        }

        public int UpdateCategory(Category cat)
        {
            int result = 0;
            var cate=db.Categories.Where(x=>x.Catid==cat.Catid).FirstOrDefault();
            if (cate != null)
            {
                cate.Catname= cat.Catname;
                result= db.SaveChanges();
            }
            return result;

        }
    }
}
