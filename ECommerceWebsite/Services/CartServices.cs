using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;

namespace ECommerceWebsite.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository repo;
        public CartServices(ICartRepository repo)
        {
            this.repo = repo;
        }

        public int AddCart(Cart cart)
        {
            return repo.AddCart(cart);
        }

        public int DeleteCart(int id)
        {
            return repo.DeleteCart(id);
        }

        public IEnumerable<Cart> GetAllCart()
        {
            return repo.GetAllCart();
        }

        public Cart GetCartById(int id)
        {
            return repo.GetCartById(id);
        }

        public int UpdateCart(Cart cart)
        {
            return repo.UpdateCart(cart);
        }
        public IEnumerable<Cart> GetCartByUserid(int id)
        {
            return repo.GetCartByUserid(id);
        }
    }
}
