//Author: Krish Patel

using Microsoft.AspNetCore.Mvc;
using SpiceFlow_Stock_Manager.Entities;
using SpiceFlow_Stock_Manager.Models;
using SpiceFlow_Stock_Manager.Services;

namespace SpiceFlow_Stock_Manager.Controllers
{
    [Route("Client")]
    public class ClientController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly ISpiceServices _spiceServices;
        private readonly IUserServices _userServices;

        public ClientController(IOrderServices orderServices, ISpiceServices spiceServices, IUserServices userServices)
        {
            _orderServices = orderServices;
            _spiceServices = spiceServices;
            _userServices = userServices;
        }

        private static List<int> ParseCart(string? cart)
        {
            if (string.IsNullOrWhiteSpace(cart))
                return new List<int>();

            return cart
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(s => int.TryParse(s, out var id) ? id : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id!.Value)
                .ToList();
        }

        [HttpGet("AvailableSpices")]
        public IActionResult AvailableSpices(int userId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            ViewBag.User = user;
            var spices = _spiceServices.GetAllSpicesInStock();
            return View(spices);
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart(int userId, int spiceId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            user.Cart = string.IsNullOrWhiteSpace(user.Cart)
                ? spiceId.ToString()
                : user.Cart + "," + spiceId;

            _userServices.UpdateUser(user);

            TempData["Message"] = "Added to cart.";
            
            return RedirectToAction("AvailableSpices", new { userId = userId });
        }

        [HttpGet("Cart")]
        public IActionResult Cart(int userId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            var spiceIds = ParseCart(user.Cart);
            var spices = _spiceServices.GetAllSpices()
                .Where(s => spiceIds.Contains(s.SpiceId))
                .ToList();

            var cartItems = spices
                .GroupBy(s => s.SpiceId)
                .Select(g =>
                {
                    var first = g.First();
                    var quantity = spiceIds.Count(id => id == first.SpiceId);
                    return new CartItemViewModel
                    {
                        SpiceId = first.SpiceId,
                        SpiceName = first.SpiceName,
                        Quantity = quantity,
                        Price = first.Price,
                        Subtotal = first.Price * quantity,
                        ImageUrl = first.ImageUrl
                    };
                })
                .ToList();

            ViewBag.User = user;
            ViewBag.Total = cartItems.Sum(i => i.Subtotal);
            return View(cartItems);
        }

        [HttpPost("RemoveFromCart")]
        public IActionResult RemoveFromCart(int userId, int spiceId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            var ids = ParseCart(user.Cart);
            var index = ids.IndexOf(spiceId);
            if (index >= 0)
            {
                ids.RemoveAt(index);
                user.Cart = string.Join(",", ids);
                _userServices.UpdateUser(user);
            }

            TempData["Message"] = "Item removed from cart.";

            return RedirectToAction("Cart", new { userId = userId });
        }

        [HttpPost("Checkout")]
        public IActionResult Checkout(int userId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            var spiceIds = ParseCart(user.Cart);
            if (!spiceIds.Any())
            {
                TempData["Message"] = "Your cart is empty.";
                return RedirectToAction("Cart", new { userId = userId });
            }

            foreach (var spiceId in spiceIds)
            {
                var spice = _spiceServices.GetSpice(spiceId);
                if (spice == null || spice.Stock <= 0)
                    continue;

                spice.Stock -= 1;
                spice.Sales += 1;
                _spiceServices.UpdateSpice(spice);

                _orderServices.PlaceOrder(new Order
                {
                    UserId = user.UserId,
                    User = user,
                    SpiceId = spice.SpiceId,
                    Spice = spice,
                    OrderDate = DateTime.UtcNow,
                    ETA = DateTime.UtcNow.AddDays(7)
                });
            }

            user.Cart = "";
            _userServices.UpdateUser(user);

            TempData["Message"] = "Checkout complete.";
            
            return RedirectToAction("AvailableSpices", new { userId = userId });
        }

        [HttpGet("OrderHistory")]
        public IActionResult OrderHistory(int userId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            var orders = _orderServices.GetOrdersByUserId(userId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            ViewBag.User = user;
            return View(orders);
        }

        [HttpGet("AccountSettings")]
        public IActionResult AccountSettings(int userId)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            ViewBag.User = user;
            return View(user);
        }

        [HttpPost("UpdateAccountSettings")]
        public IActionResult UpdateAccountSettings(int userId, string? name, string? email, string? address, string? postalCode, string? phoneNumber)
        {
            var user = _userServices.GetUser(userId);
            if (user == null)
                return RedirectToAction("SignIn", "Account");

            if (!string.IsNullOrWhiteSpace(name))
                user.UserName = name;

            if (!string.IsNullOrWhiteSpace(email))
                user.Email = email;

            if (!string.IsNullOrWhiteSpace(postalCode))
                user.PostalCode = postalCode;

            if (!string.IsNullOrWhiteSpace(address))
                user.Address = address;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
                user.PhoneNumber = phoneNumber;

            _userServices.UpdateUser(user);

            TempData["Message"] = "Account settings updated.";
            
            ViewBag.User = user;
            return View("AccountSettings", user);
        }
    }
}