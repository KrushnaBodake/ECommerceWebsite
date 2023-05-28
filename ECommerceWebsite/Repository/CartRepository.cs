using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext db;
        public CartRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCart(Cart cart)
        {
            int result = 0;
            db.Carts.Add(cart);
            result= db.SaveChanges();
            return result;
        }

        public int DeleteCart(int id)
        {
            int result = 0;
            var car = db.Carts.Where(x => x.Cartid == id).FirstOrDefault();
            if (car!= null)
            {
                db.Carts.Remove(car);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Cart> GetAllCart()
        {
            return db.Carts.ToList();
        }

        public Cart GetCartById(int id)
        {
            var cart= db.Carts.Where(x=>x.Cartid== id).FirstOrDefault();
            return cart;
        }

        public int UpdateCart(Cart cart)
        {
            int result = 0;
            var car =db.Carts.Where(x => x.Cartid == cart.Cartid).FirstOrDefault();
            if (car != null)
            {
                car.Cartid = cart.Cartid;
                car.Id = cart.Id;
                db.SaveChanges();
            }
            return result;
        }
        public IEnumerable<Cart> GetCartByUserid(int id)
        {
           
            return db.Carts.ToList().Where(x=>x.Id==id);
        }
    }
}
