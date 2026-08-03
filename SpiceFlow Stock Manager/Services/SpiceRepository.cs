// Author: Mohamed
// Purpose: Repository class for managing Spice entities in the database
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public class SpiceRepository : ISpiceServices
    {
        private readonly OrderDbContext _context;

        public SpiceRepository(OrderDbContext context)
        {
            _context = context;
        }

        public Spice AddSpice(Spice spice)
        {
            _context.Spices.Add(spice);
            _context.SaveChanges();
            return spice;
        }

        public List<Spice> GetAllSpices()
        {
            return _context.Spices.ToList();
        }

        public List<Spice> GetAllSpicesInStock()
        {
            return _context.Spices.Where(s => s.Stock > 0).ToList();
        }

        public Spice? GetSpice(int id)
        {
            return _context.Spices.FirstOrDefault(s => s.SpiceId == id);
        }

        public string RemoveSpice(int id)
        {
            var spice = _context.Spices.FirstOrDefault(s => s.SpiceId == id);
            if (spice != null)
            {
                _context.Spices.Remove(spice);
                _context.SaveChanges();
                return "Spice removed successfully.";
            }
            return "Spice not found.";
        }

        public Spice UpdateSpice(Spice spice)
        {
            _context.Spices.Update(spice);
            _context.SaveChanges();
            return spice;
        }
    }
}
