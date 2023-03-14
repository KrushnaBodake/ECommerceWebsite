
using ECommerceWebsite.Data;
using ECommerceWebsite.Models;

namespace ECommerceWebsite.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddUser(User user)
        {
            int result = 0;
            db.Users.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                result = db.SaveChanges();
            }
            return result;
        }
        public IEnumerable<User> GetAllUser()
        {
            return db.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public User GetUserById(int id)
        {
            var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public int UpdateUser(User user)
        {
            int result = 0;
            var p = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (user != null)
            {
                p.UserName = user.UserName;
                p.Email = user.Email;
                p.Password = user.Password;
                p.Contact = user.Contact;
                p.RoleId = user.RoleId;
                p.IsActive = user.IsActive;

                result = db.SaveChanges();
            }
            return result;

        }
    }
}
