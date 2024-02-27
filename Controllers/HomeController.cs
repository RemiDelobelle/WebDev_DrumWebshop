using DrumWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrumWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();            
        }

        public IActionResult Snares()
        {
            var snares = new List<Snare>
            {
                new Snare { Name="Pearl Export", Price=119, Diameter=14, Depth=5.5, PlyCount=6, Material="Popular/ Maghony", LugCount=8, Finish="Laminated", Image=Url.Content("~/Images/Snares/Pearl_Export.jpg") },
                new Snare { Name = "DW PDP Walnut", Price=325, Diameter = 14, Depth = 6.5, PlyCount = 20, Material = "Walnut", LugCount = 10, Finish="Natural", Image = Url.Content("~/Images/Snares/DW_PDP_Walnut.jpg") },
                new Snare { Name = "Sonor AS 12 Artist", Price=999, Diameter = 14, Depth = 6, PlyCount = 9, Material = "Maple", LugCount = 10, Finish="Matt Lacquered", Image = Url.Content("~/Images/Snares/Sonor_AS12_Artist.jpg") },
            };

            return View(snares);
        }
        public IActionResult Hihats()
        {
            var hihats = new List<Hihat>
            {
                new Hihat { Name="Zildjian A-Series New Beat", Price=459, Size=14, Material="Copper/ Tin", Finish="Regular/ Traditional", Sound="Solid", Image=Url.Content("~/Images/Hihats/Zildjian_A.jpg") },
                new Hihat { Name="Zultan Q", Size=14, Price=198, Material="B20 Bronze", Finish="High-gloss polished/ Untreated raw", Sound="Warm basic tone with assertive dynamic range", Image=Url.Content("~/Images/Hihats/Zultan_Q.jpg") },
                new Hihat { Name="Paiste PSTX Swiss", Price=111, Size=10, Material="Bronze/ Brass", Finish="Slik matte", Sound="Dry assertive", Image=Url.Content("~/Images/Hihats/Paiste_PSTX.jpg") },
                new Hihat { Name="Zultan Caz", Price=218, Size=15, Material="B20 Bronze", Finish="Polished", Sound="Deep voluminous clear with pleasant mixture of warmth and assertiveness", Image=Url.Content("~/Images/Hihats/Zultan_Caz.jpg") },
                new Hihat { Name="Istanbul Agop Xist Dry Dark", Price=238, Size=13, Material="B20 Bronze", Finish="Raw", Sound="Short trashy", Image=Url.Content("~/Images/Hihats/Istanbul_Agop.jpg") },
                new Hihat { Name="Paiste 2002 Classic", Price=435, Size=15, Material="CuSn8 alloy", Finish="Polished", Sound="Medium bright, full, brilliant", Image=Url.Content("~/Images/Hihats/Paiste_2002Classic.jpg") },
                new Hihat { Name="Paiste PST3", Price=79, Size=14, Material="Brass", Finish="Natural", Sound="Medium bright, clear, full", Image=Url.Content("~/Images/Hihats/Paiste_PST3.jpg") },
            };

            return View(hihats);
        }

        public IActionResult Privacy()
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
