// Author: Mohamed
// Purpose: Interface defining operations for managing Orders in a RESTful manner
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public interface IOrderServices
    {
        // CRUD operations for Orders
        List<Order> GetAllOrders();
        Order? GetOrder(int id);
        string RemoveOrder(int id);
        Order PlaceOrder(Order order);
        Order UpdateOrder(Order order);
        IEnumerable<Order> GetOrdersByUserId(int userId);
        IEnumerable<Order> GetOrdersBySpiceId(int spiceId);
    }
}
