// Author: Mohamed
// Purpose: Declaring what a 'Spice' is in the system
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpiceFlow_Stock_Manager.Entities
{
    public class Spice
    {
        // Primary Key
        [Key]
        public int SpiceId { get; set; }

        // Display Name for UI
        [DisplayName("Spice")]
        public string SpiceName { get; set; }

        // Quantity in stock
        public int Stock { get; set; }

        // How many sales have been made
        public int Sales { get; set; }

        // An image of what the Spice looks like
        public string ImageUrl { get; set; }

        public int Price { get; set; }

        // Country of origin
        public string Origin { get; set; }

        // How spicy it is
        public int ScovilleRating { get; set; }

        // When it will expire
        public DateTime ExpiryDate { get; set; }
    }
}
