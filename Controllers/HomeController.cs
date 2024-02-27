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
                new Snare { Name = "DW PDP Walnut", Price=325, Diameter = 14, Depth = 6.5, PlyCount=20, Material = "Walnut", LugCount = 10, Finish="Natural", Image = Url.Content("~/Images/Snares/DW_PDP_Walnut.jpg") },
                new Snare { Name = "DW Alex González", Price=2390, Diameter = 14, Depth = 6.5, PlyCount=11, Material = "Maple", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/DW_AlexGonzalez.jpg") },
                new Snare { Name = "Sonor Select Jungle", Price=169, Diameter = 10, Depth = 2, PlyCount=9, Material = "Maple", LugCount = 6, Finish="Natural Semi-Gloss", Image = Url.Content("~/Images/Snares/Sonor_Jungle.jpg") },
                new Snare { Name = "Sonor SSD Benny Grep", Price=888, Diameter = 13, Depth = 5.75, PlyCount=9, Material = "Beech", LugCount = 8, Finish="Satin Scandinavian Birch veneer", Image = Url.Content("~/Images/Snares/Sonor_SSDBennyG.jpg") },
                new Snare { Name = "Ludwig Supraphonic", Price=769, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Aluminium", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_Supraphonic.jpg") },
                new Snare { Name = "Yamaha Stage Custom", Price=169, Diameter = 14, Depth = 5.5, PlyCount=0, Material = "Steel", LugCount = 8, Finish="", Image = Url.Content("~/Images/Snares/Yamaha_StageCustom.jpg") },
                new Snare { Name = "Pearl S1330B", Price=314, Diameter = 13, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_S1330B.jpg") },
                new Snare { Name = "Pearl Fire Cracker", Price=243, Diameter = 10, Depth = 5, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_FireCracker.jpg") },
                new Snare { Name = "Ludwig LB417 Bl Beauty", Price=1035, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_LB417.jpg") },
                new Snare { Name = "Pearl B1330 Piccolo", Price=371, Diameter = 13, Depth = 3, PlyCount=0, Material = "Brass", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_B1330Piccolo.jpg") },
                new Snare { Name = "Ludwig Carl Palmer", Price=444, Diameter = 14, Depth = 3.7, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_CarlPalmer.jpg") },
                new Snare { Name = "Meinl Snare Timbale", Price=155, Diameter = 10, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Meinl_Timbale.jpg") },
            };

            //var snares = new List<Snare>
            //{
            //    new Snare("Pearl Export", 119, 14, 5.5, 6, "Popular/ Mahogany", 8, "Laminated", Url.Content("~/Images/Snares/Pearl_Export.jpg")),
            //    new Snare("DW PDP Walnut", 325, 14, 6.5, 20, "Walnut", 10, "Natural", Url.Content("~/Images/Snares/DW_PDP_Walnut.jpg")),
            //    new Snare("DW Alex González", 2390, 14, 6.5, 11, "Maple", 10, "", Url.Content("~/Images/Snares/DW_AlexGonzalez.jpg")),
            //    new Snare("Sonor Select Jungle", 169, 10, 2, 9, "Maple", 6, "Natural Semi-Gloss", Url.Content("~/Images/Snares/Sonor_Jungle.jpg")),
            //    new Snare("Sonor SSD Benny Grep", 888, 13, 5.75, 9, "Beech", 8, "Satin Scandinavian Birch veneer", Url.Content("~/Images/Snares/Sonor_SSDBennyG.jpg")),
            //    new Snare("Ludwig Supraphonic", 769, 14, 6.5, 0, "Aluminium", 10, "", Url.Content("~/Images/Snares/Ludwig_Supraphonic.jpg")),
            //    new Snare("Yamaha Stage Custom", 169, 14, 5.5, 0, "Steel", 8, "", Url.Content("~/Images/Snares/Yamaha_StageCustom.jpg")),
            //    new Snare("Pearl S1330B", 314, 13, 3, 0, "Steel", 6, "", Url.Content("~/Images/Snares/Pearl_S1330B.jpg")),
            //    new Snare("Pearl Fire Cracker", 243, 10, 5, 0, "Steel", 6, "", Url.Content("~/Images/Snares/Pearl_FireCracker.jpg")),
            //    new Snare("Ludwig LB417 Bl Beauty", 1035, 14, 6.5, 0, "Brass", 10, "", Url.Content("~/Images/Snares/Ludwig_LB417.jpg")),
            //    new Snare("Pearl B1330 Piccolo", 371, 13, 3, 0, "Brass", 6, "", Url.Content("~/Images/Snares/Pearl_B1330Piccolo.jpg")),
            //    new Snare("Ludwig Carl Palmer", 444, 14, 3.7, 0, "Brass", 10, "", Url.Content("~/Images/Snares/Ludwig_CarlPalmer.jpg")),
            //    new Snare("Meinl Snare Timbale", 155, 10, 3, 0, "Steel", 6, "", Url.Content("~/Images/Snares/Meinl_Timbale.jpg"))
            //};

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
