using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext db;
        public OrderRepo(ApplicationDbContext db)
        {
           this.db = db;
        }
        public int AddOrder(Order order)
        {
            int result = 0;
            db.Orders.Add(order);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteOrder(int id)
        {
            int result = 0;
            var order=db.Orders.Where(x => x.Oid == id).FirstOrDefault();
            if(order!=null)
            {
                db.Orders.Remove(order);
                result = db.SaveChanges();
            }


            return result;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Order> GetCartByProdId(int id)
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Order> GetCartByUserId(int id)
        {
            return db.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            var order= db.Orders.Where(x=>x.Oid== id).FirstOrDefault();
            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            var odr =db.Orders.Where(x => x.Oid == order.Oid).FirstOrDefault();
            if(odr!=null)
            {
                odr.ProdId = order.ProdId;
                odr.Id = order.Id;
                odr.Qty= order.Qty;
                result=db.SaveChanges();
            }
            return result;
        }
    }
}
