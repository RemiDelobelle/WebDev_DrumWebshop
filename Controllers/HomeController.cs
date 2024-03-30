using DrumWebshop.Data;
using DrumWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DrumWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DrumContext _drumContext;

        public HomeController(ILogger<HomeController> logger, DrumContext drumContext)
        {
            _logger = logger;
            _drumContext = drumContext;
        }

        public IActionResult Index()
        {
            return View();            
        }

        public IActionResult Snares()
        {
            var snaresList = _drumContext.Products.OfType<Snare>().ToList();
            return View(snaresList);
        }
        public IActionResult Shells()
        {
            var shellsList = _drumContext.Products.OfType<Shell>().ToList();
            return View(shellsList);
        }
        public IActionResult Hihats()
        {
            var hihatsList = _drumContext.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Hihat).ToList();
            return View(hihatsList);
        }
        public IActionResult Crashes()
        {
            var crashesList = _drumContext.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Crash).ToList();
            return View(crashesList);
        }
        public IActionResult Rides()
        {
            var ridesList = _drumContext.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Ride).ToList();
            return View(ridesList);
        }
        public IActionResult Hardware()
        {
            var hardwareList = _drumContext.Products.OfType<Hardware>().ToList();
            return View(hardwareList);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddToCart(int productId, string returnUrl)
        {
            var productToAdd = _drumContext.Products.FirstOrDefault(p => p.Id == productId);

            if (productToAdd != null)
            {
                var existingCartItem = _drumContext.CartItems.FirstOrDefault(c => c.Product.Id == productId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _drumContext.Update(existingCartItem);
                    _logger.LogInformation($"[INFO] {existingCartItem} already in cart: now {existingCartItem.Quantity}x");
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        Product = productToAdd,
                        Quantity = 1
                    };
                    _drumContext.CartItems.Add(cartItem);
                    _logger.LogInformation($"[INFO] {cartItem} added to cart");
                }

                _drumContext.SaveChanges();
            }

            return Redirect(returnUrl);
        }

        public IActionResult ShoppingCart()
        {
            var cartItems = _drumContext.CartItems.Include(c => c.Product).ToList();
            _logger.LogInformation($"[INFO] Retrieved items for shopping cart: {cartItems.Count} different items");

            return View(cartItems);
        }

        public IActionResult AddExtra(int productId)
        {
            var cartItemToAdd = _drumContext.CartItems.FirstOrDefault(c => c.Product.Id == productId);

            if (cartItemToAdd != null)
            {
                cartItemToAdd.Quantity++;
                _drumContext.SaveChanges();
                _logger.LogInformation($"[INFO] {cartItemToAdd}: Quantity + 1");
            }

            return RedirectToAction("ShoppingCart");
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItemToRemove = _drumContext.CartItems.FirstOrDefault(c => c.Product.Id == productId);

            if (cartItemToRemove != null)
            {
                if (cartItemToRemove.Quantity > 1)
                {
                    cartItemToRemove.Quantity--;
                    _logger.LogInformation($"[INFO] {cartItemToRemove}: Quantity - 1");
                }
                else
                {
                    _drumContext.CartItems.Remove(cartItemToRemove);
                    _logger.LogInformation($"[INFO] {cartItemToRemove} removed");
                }
                _drumContext.SaveChanges();
            }

            return RedirectToAction("ShoppingCart");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
