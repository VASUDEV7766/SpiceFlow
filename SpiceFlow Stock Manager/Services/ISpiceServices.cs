// Author: Mohamed
// Purpose: Interface for Spice services
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public interface ISpiceServices
    {
        List<Spice> GetAllSpices();
        List<Spice> GetAllSpicesInStock();
        Spice? GetSpice(int id);
        string RemoveSpice(int id);
        Spice AddSpice(Spice spice);
        Spice UpdateSpice(Spice spice);
    }
}
