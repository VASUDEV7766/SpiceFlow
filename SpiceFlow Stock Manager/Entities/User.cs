// Author: Mohamed
// Purpose: Declaring what a 'User' is in the system
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpiceFlow_Stock_Manager.Entities
{
    public class User
    {
        // Primary Key
        [Key]
        public int UserId { get; set; }

        // Name of the user
        [DisplayName("User")]
        public string UserName { get; set; }

        // Email of the user
        public string Email { get; set; }

        // Password of the user
        public string Password { get; set; }

        // Phone number of the user
        public string PhoneNumber { get; set; }

        // Delivery address (street, city, province)
        public string Address { get; set; }

        // User's postal code (Canadian format)
        public string PostalCode { get; set; }

        // If the user is a manager or not
        public bool IsManager { get; set; }

        // User's shopping cart (serialized as a string); ex: "spiceId,spiceId,spiceId,..."
        public string Cart { get; set; }
    }
}
