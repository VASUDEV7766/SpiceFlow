// Author: Vasudev Plavinchuvadu Vinod
// Purpose: Manager-facing actions for managing spices and viewing orders.

using Microsoft.AspNetCore.Mvc;
using SpiceFlow_Stock_Manager.Entities;
using SpiceFlow_Stock_Manager.Services;

namespace SpiceFlow_Stock_Manager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ISpiceServices _spiceServices;
        private readonly IOrderServices _orderServices;

        public ManagerController(ISpiceServices spiceServices, IOrderServices orderServices)
        {
            _spiceServices = spiceServices;
            _orderServices = orderServices;
        }

        // GET: /Manager/Spices
        // List all spices for the manager to manage.
        public IActionResult Spices()
        {
            var spices = _spiceServices.GetAllSpices();
            return View(spices);
        }

        // GET: /Manager/CreateSpice
        // Show form to create a new spice.
        [HttpGet]
        public IActionResult CreateSpice()
        {
            return View(new Spice());
        }

        // POST: /Manager/CreateSpice
        // Create a new spice in the system.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSpice(Spice spice)
        {
            if (!ModelState.IsValid)
            {
                return View(spice);
            }

            _spiceServices.AddSpice(spice);
            return RedirectToAction(nameof(Spices));
        }

        // GET: /Manager/EditSpice/5
        // Show form to edit an existing spice.
        [HttpGet]
        public IActionResult EditSpice(int id)
        {
            var spice = _spiceServices.GetSpice(id);
            if (spice == null)
            {
                return NotFound();
            }

            return View(spice);
        }

        // POST: /Manager/EditSpice
        // Save changes to an existing spice.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSpice(Spice spice)
        {
            if (!ModelState.IsValid)
            {
                return View(spice);
            }

            _spiceServices.UpdateSpice(spice);
            return RedirectToAction(nameof(Spices));
        }

        // GET: /Manager/SpiceDetails/5
        // Show a single spice with full details.
        [HttpGet]
        public IActionResult SpiceDetails(int id)
        {
            var spice = _spiceServices.GetSpice(id);
            if (spice == null)
            {
                return NotFound();
            }

            return View(spice);
        }

        // GET: /Manager/DeleteSpice/5
        // Confirm delete page.
        [HttpGet]
        public IActionResult DeleteSpice(int id)
        {
            var spice = _spiceServices.GetSpice(id);
            if (spice == null)
            {
                return NotFound();
            }

            return View(spice);
        }

        // POST: /Manager/DeleteSpiceConfirmed/5
        // Actually delete the spice.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSpiceConfirmed(int id)
        {
            _spiceServices.RemoveSpice(id);
            return RedirectToAction(nameof(Spices));
        }

        // GET: /Manager/Orders
        // List all orders for manager.
        public IActionResult Orders()
        {
            var orders = _orderServices.GetAllOrders();
            return View(orders);
        }

    }
}
