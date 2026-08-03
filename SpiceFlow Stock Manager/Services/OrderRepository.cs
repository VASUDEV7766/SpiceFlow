// Author: Mohamed
// Purpose: Repository class for managing Order entities in the database
using Microsoft.EntityFrameworkCore;
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public class OrderRepository : IOrderServices
    {
        // Database context for accessing Orders table
        private readonly OrderDbContext _context;

        // Constructor to initialize the database context
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Spice)
                .Include(o => o.User)
                .ToList();
        }

        public Order? GetOrder(int id)
        {
            return _context.Orders
                .Include(o => o.Spice)
                .Include(o => o.User)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public Order PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public string RemoveOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return "Order removed successfully.";
            }
            return "Order not found.";
        }

        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _context.Orders
                .Include(o => o.Spice)
                .Include(o => o.User)
                .Where(o => o.UserId == userId)
                .ToList();
        }

        public IEnumerable<Order> GetOrdersBySpiceId(int spiceId)
        {
            return _context.Orders
                .Include(o => o.Spice)
                .Include(o => o.User)
                .Where(o => o.SpiceId == spiceId)
                .ToList();
        }
    }
}
