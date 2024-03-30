using DrumWebshop.Controllers;
using DrumWebshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrumWebshop.Data;
using DrumWebshop.Models;

namespace DrumWebshop.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DrumContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ILogger<HomeController> logger, DrumContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShoppingCart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);

                if (await _userManager.IsInRoleAsync(user, "PendingMember"))
                {
                    return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
                }

                var cartItems = await _context.CartItems
                    .Include(c => c.Product)
                    .Where(c => c.UserId == user.Id && !c.IsCheckedOut)
                    .ToListAsync();

                _logger.LogInformation($"Retrieved items in shopping cart: {cartItems.Count} different items");

                return View(cartItems);
            }
        }

        public async Task<IActionResult> CheckedOutItems()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Member") && !User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            var user = await _userManager.GetUserAsync(User);
            var checkedOutItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id && c.IsCheckedOut)
                .GroupBy(c => c.Product.Id)
                .Select(group => new CartItem
                {
                    Product = group.First().Product,
                    Quantity = group.Sum(c => c.Quantity)
                })
                .ToListAsync();

            return View(checkedOutItems);
        }


        public async Task<IActionResult> AddExtra(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItemToAdd = await _context.CartItems.FirstOrDefaultAsync(c => c.Product.Id == productId && c.UserId == user.Id && !c.IsCheckedOut);

            if (cartItemToAdd != null)
            {
                cartItemToAdd.Quantity++;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItemToRemove = await _context.CartItems.FirstOrDefaultAsync(c => c.Product.Id == productId && c.UserId == user.Id && !c.IsCheckedOut);

            if (cartItemToRemove != null)
            {
                if (cartItemToRemove.Quantity > 1)
                {
                    cartItemToRemove.Quantity--;
                }
                else
                {
                    _context.CartItems.Remove(cartItemToRemove);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItemsToCheckout = await _context.CartItems
                                           .Include(c => c.Product)
                                           .Where(c => c.UserId == user.Id && !c.IsCheckedOut)
                                           .ToListAsync();

            foreach (var cartItem in cartItemsToCheckout)
            {
                var existingCheckedOutItem = await _context.CartItems
                    .FirstOrDefaultAsync(c => c.Product.Id == cartItem.Product.Id && c.IsCheckedOut);

                if (existingCheckedOutItem != null && existingCheckedOutItem.UserId == user.Id)
                {
                    existingCheckedOutItem.Quantity += cartItem.Quantity;
                    _context.Remove(cartItem);
                    _context.Update(existingCheckedOutItem);
                }
                else
                {
                    cartItem.IsCheckedOut = true;
                    _context.Update(cartItem);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
