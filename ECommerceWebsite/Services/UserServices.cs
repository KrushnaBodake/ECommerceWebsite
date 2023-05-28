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
            user.RoleId = 2;
            user.IsActive = 1;
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
            user.RoleId = 2;
            user.IsActive = 1;
            return repo.UpdateUser(user);
        }

        public User GetUserByEmail(string email)
        {
            return repo.GetUserByEmail(email);
        }
    }
}
