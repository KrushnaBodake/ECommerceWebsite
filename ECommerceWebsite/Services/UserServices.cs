using ECommerceWebsite.Models;
using ECommerceWebsite.Repository;

namespace ECommerceWebsite.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository repo;
        public UserServices(IUserRepository repo)
        {
            this.repo = repo;
        }
        public int AddUser(User user)
        {
            return repo.AddUser(user);
        }

        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUser()
        {
            return repo.GetAllUser();
        }

        public User GetUserById(int id)
        {
            return repo.GetUserById(id);
        }

        public int UpdateUser(User user)
        {
            return repo.UpdateUser(user);
        }
    }
}
