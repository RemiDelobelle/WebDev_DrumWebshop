using DrumWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DrumWebshop.Data;
using DrumWebshop.Models;

namespace DrumWebshop.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly DrumContext _context;

        public ManagerController(ILogger<ManagerController> logger, DrumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult ManagerPanel(string sortOrder = "Type")
        {
            _logger.LogInformation("ManagerPanel clicked");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = true });
            }
            if (!User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                return RedirectToAction("AccessDenied", "Home", new { notLoggedIn = false });
            }

            var checkedOutItems = _context.CartItems
                .Where(c => c.IsCheckedOut)
                .GroupBy(c => c.Product.Id) // Group by ProductId
                .Select(group => new CartItem
                {
                    Product = _context.Products.FirstOrDefault(p => p.Id == group.Key), // Retrieve product by Id
                    Quantity = group.Sum(c => c.Quantity)
                })
                .ToList();

            var sortedItems = ApplySortOrder(checkedOutItems, sortOrder);

            return View(sortedItems);
        }

        private List<CartItem> ApplySortOrder(List<CartItem> items, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Type" => items.OrderBy(c => GetProductTypePriority(c.Product)).ToList(),
                "Type - Reverse" => items.OrderByDescending(c => GetProductTypePriority(c.Product)).ToList(),
                "Quantity - High first" => items.OrderByDescending(c => c.Quantity).ToList(),
                "Quantity - Low first" => items.OrderBy(c => c.Quantity).ToList(),
                "Price (item) - High first" => items.OrderByDescending(c => c.Product.Price).ToList(),
                "Price (item) - Low first" => items.OrderBy(c => c.Product.Price).ToList(),
                "Name - Alphabetical" => items.OrderBy(c => c.Product.Name).ToList(),
                "Name - Reverse Alphabetical" => items.OrderByDescending(c => c.Product.Name).ToList(),
                "-" => items,
                _ => items,
            };
        }
        private int GetProductTypePriority(Product product)
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
                return 7; // Other product types
            }
        }
    }
}
