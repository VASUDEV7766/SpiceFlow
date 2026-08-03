//Author: Dominic Becz
//Purpose: Controller for managing user accounts, including sign-in, registration, password recovery, and sign-out.

using Microsoft.AspNetCore.Mvc;
using SpiceFlow_Stock_Manager.Models;
using SpiceFlow_Stock_Manager.Services;
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userRepository;

        public AccountController(IUserServices userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            var user = _userRepository.GetUserByEmail(model.Email!);
            if (user == null || user.Password != model.Password)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            if (user.IsManager)
            {
                // Redirect to ManagerController.Spices
                return RedirectToAction("Spices", "Manager");
            }

            // Regular client flow: Redirect to Client/AvailableSpices and pass only the user's id
            return RedirectToAction("AvailableSpices", "Client", new { userId = user.UserId });
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailAvailable(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Json(false);

            var user = _userRepository.GetUserByEmail(email);
            return Json(user == null);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if user already exists
            var existingUser = _userRepository.GetUserByEmail(model.Email!);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "An account with this email already exists.");
                return View(model);
            }

            // Create new user
            var newUser = new User
            {
                UserName = model.Name!,
                Email = model.Email!,
                Password = model.Password!,
                Address = model.Address ?? string.Empty,
                PhoneNumber = model.PhoneNumber ?? string.Empty,
                PostalCode = model.PostalCode ?? string.Empty,
                IsManager = false,
                Cart = string.Empty
            };

            _userRepository.AddUser(newUser);
            TempData["Message"] = "Registration successful! Please sign in.";
            return RedirectToAction("SignIn");
        }

        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.GetUserByEmail(model.Email!);
            if (user == null)
            {
                // Don't reveal that user doesn't exist for security
                TempData["Message"] = "If an account exists with this email, the password has been reset.";
                return RedirectToAction("SignIn");
            }

            // Update user password
            user.Password = model.NewPassword!;
            _userRepository.UpdateUser(user);

            TempData["Message"] = "Password has been reset successfully!";
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
