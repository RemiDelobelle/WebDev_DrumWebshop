using DrumWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrumWebshop.Data;
using DrumWebshop.Models;
using DrumWebshop.ViewModel;

namespace DrumWebshop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly DrumContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ILogger<AdminController> logger, DrumContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> UserManagement()
        {
            _logger.LogInformation("going to UserManagement");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            var users = _userManager.Users.ToList();

            var usersWithRoles = users.Select(user =>
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                return new { User = user, Roles = roles };
            }).ToList();

            var sortedUsers = usersWithRoles.OrderBy(u =>
            {
                if (u.Roles.Contains("Admin"))
                    return 4;
                else if (u.Roles.Contains("Manager"))
                    return 3;
                else if (u.Roles.Contains("Member"))
                    return 2;
                else
                    return 1;
            }).Select(u => u.User).ToList();

            return View(sortedUsers);
        }
        [HttpPost]
        public async Task<IActionResult> AcceptPendingMember(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, "PendingMember"))
            {
                await _userManager.RemoveFromRoleAsync(user, "PendingMember");
                await _userManager.AddToRoleAsync(user, "Member");
            }

            return RedirectToAction(nameof(UserManagement));
        }

        [HttpPost]
        public async Task<IActionResult> PromoteToAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, "Manager"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Manager");
            }
            if (await _userManager.IsInRoleAsync(user, "Member"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Member");
            }
            await _userManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction("UserManagement");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Account does not exist!";
                TempData["ShowPopup"] = true;
                return RedirectToAction("UserManagement");
            }

            if (_userManager.GetUserId(User) == userId)
            {
                TempData["ErrorMessage"] = "You cannot remove your own account!";
                TempData["ShowPopup"] = true;
                return RedirectToAction("UserManagement");
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Manager");
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }

            return RedirectToAction(nameof(UserManagement));
        }
        [HttpPost]
        public async Task<IActionResult> PromoteToManager(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Manager");
                await _userManager.RemoveFromRoleAsync(user, "Member");
            }
            return RedirectToAction("UserManagement");
        }
        [HttpPost]
        public async Task<IActionResult> PromoteToMember(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Member");
                await _userManager.RemoveFromRoleAsync(user, "Manager");
            }
            return RedirectToAction("UserManagement");
        }

        public IActionResult CreateAdmin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "User with this email already exists.");
                    return View();
                }

                // Create a new user
                var newUser = new IdentityUser { UserName = email, Email = email };
                var result = await _userManager.CreateAsync(newUser, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                    return RedirectToAction("UserManagement", "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
            }
            return View();
        }

        public IActionResult UserOrders()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            var checkedOutItems = _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.IsCheckedOut)
                .ToList();

            var users = _context.Users.ToList();

            var viewModel = new UserOrdersVM
            {
                Users = users,
                Orders = checkedOutItems
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult DeleteAllCheckedOutItems()
        {
            var checkedOutItems = _context.CartItems
                .Where(c => c.IsCheckedOut)
                .ToList();

            _context.CartItems.RemoveRange(checkedOutItems);
            _context.SaveChanges();

            return RedirectToAction(nameof(UserOrders));
        }
        [HttpPost]
        public IActionResult DeleteCheckedOutItemsUser(string userId)
        {
            var checkedOutItems = _context.CartItems
                .Where(c => c.IsCheckedOut && c.UserId == userId)
                .ToList();

            _context.CartItems.RemoveRange(checkedOutItems);
            _context.SaveChanges();

            return RedirectToAction(nameof(UserOrders));
        }
        public async Task<IActionResult> AddOne(int cartItemId)
        {
            var orderToAdd = await _context.CartItems.FirstOrDefaultAsync(o => o.Id == cartItemId && o.IsCheckedOut == true);

            if (orderToAdd != null)
            {
                orderToAdd.Quantity++;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("UserOrders");
        }
        public async Task<IActionResult> RemoveOne(int cartItemId)
        {
            var orderToRemove = await _context.CartItems.FirstOrDefaultAsync(o => o.Id == cartItemId && o.IsCheckedOut == true);

            if (orderToRemove != null)
            {
                if (orderToRemove.Quantity > 1)
                {
                    orderToRemove.Quantity--;
                }
                else
                {
                    _context.CartItems.Remove(orderToRemove);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("UserOrders");
        }

        public IActionResult ChangePrices(string sortOrder = "Type")
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            var products = _context.Products.ToList();
            products = ApplySortOrder(products, sortOrder);
            return View(products);
        }
        private List<Product> ApplySortOrder(List<Product> products, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Type" => products.OrderBy(GetTypePriority).ToList(),
                "Type - Reverse" => products.OrderByDescending(GetTypePriority).ToList(),
                "Price (item) - High first" => products.OrderByDescending(p => p.Price).ToList(),
                "Price (item) - Low first" => products.OrderBy(p => p.Price).ToList(),
                "Name - Alphabetical" => products.OrderBy(p => p.Name).ToList(),
                "Name - Reverse Alphabetical" => products.OrderByDescending(p => p.Name).ToList(),
                "-" => products,
                _ => products,
            };
        }
        private int GetTypePriority(Product product)
        {
            if (product is Snare)
            {
                return 1;
            }
            else if (product is Shell)
            {
                return 2;
            }
            else if (product is Cymbal c)
            {
                return c.Type == CymbalType.Hihat ? 3 :
                       c.Type == CymbalType.Crash ? 4 :
                       c.Type == CymbalType.Ride ? 5 :
                       7;
            }
            else if (product is Hardware)
            {
                return 6;
            }
            else
            {
                return 7;
            }
        }
        [HttpPost]
        public IActionResult UpdatePrice(int productId, int newPrice)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _logger.LogInformation("product IS NOT null", product.Name, newPrice);
                product.Price = newPrice;

                foreach (var cartItem in _context.CartItems.Where(c => c.Product.Id == productId && c.IsCheckedOut == false))
                {
                    cartItem.Product.Price = newPrice;
                    _context.Update(cartItem);
                }
                _context.Update(product);
                _context.SaveChanges();
            }

            return RedirectToAction("ChangePrices");
        }
    }
}
