using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public interface ICartRepository
    {
        
        IEnumerable<Cart> GetAllCart();
        Cart GetCartById(int id);
        int AddCart(Cart cart);
        int UpdateCart(Cart cart);
        int DeleteCart(int id);
        IEnumerable<Cart> GetCartByUserid(int id);
    }
}
