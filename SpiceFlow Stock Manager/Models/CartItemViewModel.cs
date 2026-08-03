// Author: Mohamed

namespace SpiceFlow_Stock_Manager.Models
{
    public class CartItemViewModel
    {
        public int SpiceId { get; set; }
        public string SpiceName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public decimal Subtotal { get; set; }
        public string ImageUrl { get; set; }
    }
}
