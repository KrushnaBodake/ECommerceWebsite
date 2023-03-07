using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var prod= db.Products.Where(x=>x.Prodid==id).FirstOrDefault();
            if(prod!=null)
            {
                db.Products.Remove(prod);
                result= db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var prod=db.Products.Where(x => x.Prodid == id).FirstOrDefault();
            return prod;
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            var prod= db.Products.Where(x=>x.Prodid==product.Prodid).FirstOrDefault();
            if(prod!=null)
            {
                prod.Prodname = product.Prodname;
                prod.Price = product.Price;
                prod.ImageUrl = product.ImageUrl;
                prod.Company = product.Company;
                prod.Catid = product.Catid;
                prod.Discount = product.Discount;
                prod.Description = product.Description;
                prod.Stock = product.Stock;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
