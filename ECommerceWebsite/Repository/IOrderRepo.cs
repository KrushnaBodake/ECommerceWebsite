using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public interface IOrderRepo
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);

        int AddOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(int id);
        IEnumerable<Order> GetCartByUserId(int id);
        IEnumerable<Order> GetCartByProdId(int id);


    }
}
