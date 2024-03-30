using DrumWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using DrumWebshop.Data;
using DrumWebshop.Models;

namespace DrumWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DrumContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, DrumContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Snares(string sortOrder = null)
        {
            var snaresList = _context.Products.OfType<Snare>().ToList();
            snaresList = ApplySortOrder(snaresList, sortOrder);

            return View(snaresList);
        }
        private List<Snare> ApplySortOrder(List<Snare> snares, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Diameter - High first" => snares.OrderByDescending(s => s.Diameter).ToList(),
                "Diameter - Low first" => snares.OrderBy(s => s.Diameter).ToList(),
                "Depth - High first" => snares.OrderByDescending(s => s.Depth).ToList(),
                "Depth - Low first" => snares.OrderBy(s => s.Depth).ToList(),
                "Material - Alphabetical" => snares.OrderBy(s => s.Material).ToList(),
                "Material - Reverse Alphabetical" => snares.OrderByDescending(s => s.Material).ToList(),
                "Price - High first" => snares.OrderByDescending(s => s.Price).ToList(),
                "Price - Low first" => snares.OrderBy(s => s.Price).ToList(),
                "Name - Alphabetical" => snares.OrderBy(s => s.Name).ToList(),
                "Name - Reverse Alphabetical" => snares.OrderByDescending(s => s.Name).ToList(),
                "-" => snares,
                _ => snares,
            };
        }
        public IActionResult Shells(string sortOrder = null)
        {
            var shellsList = _context.Products.OfType<Shell>().ToList();
            shellsList = ApplySortOrder(shellsList, sortOrder);

            return View(shellsList);
        }
        private List<Shell> ApplySortOrder(List<Shell> shells, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Pieces count - High first" => shells.OrderByDescending(s => s.Pieces).ToList(),
                "Pieces count - Low first" => shells.OrderBy(s => s.Pieces).ToList(),
                "Material - Alphabetical" => shells.OrderBy(s => s.Material).ToList(),
                "Material - Reverse Alphabetical" => shells.OrderByDescending(s => s.Material).ToList(),
                "Price - High first" => shells.OrderByDescending(s => s.Price).ToList(),
                "Price - Low first" => shells.OrderBy(s => s.Price).ToList(),
                "Name - Alphabetical" => shells.OrderBy(s => s.Name).ToList(),
                "Name - Reverse Alphabetical" => shells.OrderByDescending(s => s.Name).ToList(),
                "-" => shells,
                _ => shells,
            };
        }

        public IActionResult Hihats(string sortOrder = null)
        {
            var hihatsList = _context.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Hihat).ToList();
            hihatsList = ApplySortOrder(hihatsList, sortOrder);

            return View(hihatsList);
        }
        public IActionResult Crashes(string sortOrder = null)
        {
            var crashesList = _context.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Crash).ToList();
            crashesList = ApplySortOrder(crashesList, sortOrder);

            return View(crashesList);
        }
        public IActionResult Rides(string sortOrder = null)
        {
            var ridesList = _context.Products.OfType<Cymbal>().Where(c => c.Type == CymbalType.Ride).ToList();
            ridesList = ApplySortOrder(ridesList, sortOrder);

            return View(ridesList);
        }
        private List<Cymbal> ApplySortOrder(List<Cymbal> cymbals, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Size - High first" => cymbals.OrderByDescending(c => c.Size).ToList(),
                "Size - Low first" => cymbals.OrderBy(c => c.Size).ToList(),
                "Material - Alphabetical" => cymbals.OrderBy(c => c.Material).ToList(),
                "Material - Reverse Alphabetical" => cymbals.OrderByDescending(c => c.Material).ToList(),
                "Price - High first" => cymbals.OrderByDescending(c => c.Price).ToList(),
                "Price - Low first" => cymbals.OrderBy(c => c.Price).ToList(),
                "Name - Alphabetical" => cymbals.OrderBy(c => c.Name).ToList(),
                "Name - Reverse Alphabetical" => cymbals.OrderByDescending(c => c.Name).ToList(),
                "-" => cymbals,
                _ => cymbals,
            };
        }
        public IActionResult Hardware(string sortOrder = null)
        {
            var hardwareList = _context.Products.OfType<Hardware>().ToList();
            hardwareList = ApplySortOrder(hardwareList, sortOrder);

            return View(hardwareList);
        }
        private List<Hardware> ApplySortOrder(List<Hardware> hardware, string sortOrder)
        {
            // Apply sort order
            return sortOrder switch
            {
                "Price - High first" => hardware.OrderByDescending(h => h.Price).ToList(),
                "Price - Low first" => hardware.OrderBy(h => h.Price).ToList(),
                "Name - Alphabetical" => hardware.OrderBy(h => h.Name).ToList(),
                "Name - Reverse Alphabetical" => hardware.OrderByDescending(h => h.Name).ToList(),
                "-" => hardware,
                _ => hardware,
            };
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int productId, string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect(returnUrl);
            }

            var productToAdd = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            var user = await _userManager.GetUserAsync(User);

            if (productToAdd != null && user != null)
            {
                var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.Product.Id == productId && c.UserId == user.Id && c.IsCheckedOut == false);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                    _context.Update(existingCartItem);
                }
                else
                {
                    var cartItem = new CartItem(productToAdd, 1, user.Id);
                    _context.CartItems.Add(cartItem);
                }

                await _context.SaveChangesAsync();
            }

            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied(bool notLoggedIn)
        {
            ViewData["Title"] = "Access Denied";

            if (notLoggedIn)
            {
                ViewData["Message"] = "Please login first.";
            }
            else
            {
                ViewData["Message"] = "You do not have the rights to visit this page.";
            }

            ViewData["NotLoggedIn"] = notLoggedIn;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
