// Author: Mohamed
// Purpose: Interface for User services
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        User? GetUser(int id);
        string RemoveUser(int id);
        User AddUser(User user);
        User UpdateUser(User user);
        User? GetUserByEmail(string email);
    }
}
