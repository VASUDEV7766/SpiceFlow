// Author: Mohamed
// Purpose: Repository class for managing User entities in the database
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public class UserRepository : IUserServices
    {
        private readonly OrderDbContext _context;

        public UserRepository(OrderDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public string RemoveUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return "User removed successfully.";
            }
            return "User not found.";
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
