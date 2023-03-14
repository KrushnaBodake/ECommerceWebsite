using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        int AddUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
    }
}
