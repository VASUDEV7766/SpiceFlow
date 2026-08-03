// Author: Mohamed
// Purpose: Declaring what an 'Order' is in the system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiceFlow_Stock_Manager.Entities
{
    public class Order
    {
        // Unique identifier for each order
        public int OrderId { get; set; }

        // Foreign key linking to the Spice entity
        [ForeignKey("Spice")]
        public int SpiceId { get; set; }

        // Navigation property for the Spice being ordered
        public virtual Spice Spice { get; set; }

        // Foreign key linking to the User entity
        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation property for the User who placed the order
        public virtual User User { get; set; }

        // Date when the order was placed
        public DateTime OrderDate { get; set; }

        // Estimated time of arrival for the order
        public DateTime ETA { get; set; }
    }
}
