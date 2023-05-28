using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;

namespace ECommerceWebsite.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepo repo;
        public OrderServices(IOrderRepo repo)
        {
            this.repo = repo;
        }

        public int AddOrder(Order order)
        {
            return repo.AddOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return repo.DeleteOrder(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return repo.GetAllOrders();
        }

        public IEnumerable<Order> GetCartByProdId(int id)
        {
            return repo.GetCartByProdId(id);
        }

        public IEnumerable<Order> GetCartByUserId(int id)
        {
            return repo.GetCartByUserId(id);
        }

        public Order GetOrderById(int id)
        {
            return repo.GetOrderById(id);
        }

        public int UpdateOrder(Order order)
        {
            return repo.UpdateOrder(order);
        }
    }
}
