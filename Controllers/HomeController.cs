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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
