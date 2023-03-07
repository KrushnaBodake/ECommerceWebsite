using ECommerceWebsite.Models;

namespace ECommerceWebsite.Services
{
    public interface IUserServices
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        int AddUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
    }
}
