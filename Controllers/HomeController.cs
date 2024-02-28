using DrumWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
                new Snare { Name = "DW Alex González", Price=2390, Diameter = 14, Depth = 6.5, PlyCount=11, Material = "Maple", LugCount = 10, Finish="High-gloss lacquered", Image = Url.Content("~/Images/Snares/DW_AlexGonzalez.jpg") },
                new Snare { Name = "Sonor Select Jungle", Price=169, Diameter = 10, Depth = 2, PlyCount=9, Material = "Maple", LugCount = 6, Finish="Natural Semi-Gloss", Image = Url.Content("~/Images/Snares/Sonor_Jungle.jpg") },
                new Snare { Name = "Sonor SSD Benny Grep", Price=888, Diameter = 13, Depth = 5.75, PlyCount=9, Material = "Beech", LugCount = 8, Finish="Satin Scandinavian Birch veneer", Image = Url.Content("~/Images/Snares/Sonor_SSDBennyG.jpg") },
                new Snare { Name = "Ludwig Supraphonic", Price=769, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Aluminium", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_Supraphonic.jpg") },
                new Snare { Name = "Yamaha Stage Custom", Price=169, Diameter = 14, Depth = 5.5, PlyCount=0, Material = "Steel", LugCount = 8, Finish="", Image = Url.Content("~/Images/Snares/Yamaha_StageCustom.jpg") },
                new Snare { Name = "Pearl S1330B", Price=314, Diameter = 13, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_S1330B.jpg") },
                new Snare { Name = "Pearl Fire Cracker", Price=243, Diameter = 10, Depth = 5, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_FireCracker.jpg") },
                new Snare { Name = "Ludwig LB417 Bl Beauty", Price=1035, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_LB417.jpg") },
                new Snare { Name = "Pearl B1330 Piccolo", Price=371, Diameter = 13, Depth = 3, PlyCount=0, Material = "Brass", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Pearl_B1330Piccolo.jpg") },
                new Snare { Name = "Ludwig Carl Palmer", Price=444, Diameter = 14, Depth = 3.7, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = Url.Content("~/Images/Snares/Ludwig_CarlPalmer.jpg") },
                new Snare { Name = "Meinl Snare Timbale", Price=155, Diameter = 10, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = Url.Content("~/Images/Snares/Meinl_Timbale.jpg") }
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

        public IActionResult Shells()
        {
            var shells = new List<Shell>
            {
                new Shell { Name="DW PDP Concept Classic", Price=1069, Pieces=3, PlyCount=7, Material="Maple", Colour="Natural with walnut hoops", Image=Url.Content("~/Images/Shells/DW_PDP_Concept.jpg") },
                new Shell { Name="Pearl Crystal Beat Rock", Price=1625, Pieces=4, PlyCount=0, Material="Acrylic", Colour="Transparant", Image=Url.Content("~/Images/Shells/Pearl_Clear.jpg") },
                new Shell { Name="Gretsch Renown Studio", Price=1899, Pieces=4, PlyCount=7, Material="Maple", Colour="Vintage Pearl", Image=Url.Content("~/Images/Shells/Gretsch_Renown.jpg") },
                new Shell { Name="Tama Starclassic", Price=2090, Pieces=4, PlyCount=5, Material="Birch", Colour="Satin Sapphire Fade", Image=Url.Content("~/Images/Shells/Tama_Starcl.jpg") },
                new Shell { Name="Mapex Saturn Evo", Price=2899, Pieces=5, PlyCount=8, Material="Walnut", Colour="Brunswick Green", Image=Url.Content("~/Images/Shells/Mapex_SaturnEvo.jpg") },
                new Shell { Name="Ludwig Classic", Price=4399, Pieces=4, PlyCount=7, Material="Maple", Colour="Vintage Black Oyster", Image=Url.Content("~/Images/Shells/Ludwig_Classic.jpg") },
                new Shell { Name="DW Satin Oil", Price=8899, Pieces=6, PlyCount=8, Material="Maple", Colour="Satin Regal Blue", Image=Url.Content("~/Images/Shells/DW_Satin.jpg") },
            };

            return View(shells);
        }

        public IActionResult Hihats()
        {
            var hihats = new List<Cymbal>
            {
                new Cymbal { Name="Zildjian A-Series New Beat", Price=459, Size=14, Material="Copper/ Tin", Finish="Regular/ Traditional", Sound="Solid", Image=Url.Content("~/Images/Hihats/Zildjian_A.jpg") },
                new Cymbal { Name="Zultan Q", Size=14, Price=198, Material="B20 Bronze", Finish="High-gloss polished/ Untreated raw", Sound="Warm basic tone with assertive dynamic range", Image=Url.Content("~/Images/Hihats/Zultan_Q.jpg") },
                new Cymbal { Name="Paiste PSTX Swiss", Price=111, Size=10, Material="Bronze/ Brass", Finish="Slik matte", Sound="Dry assertive", Image=Url.Content("~/Images/Hihats/Paiste_PSTX.jpg") },
                new Cymbal { Name="Zultan Caz", Price=218, Size=15, Material="B20 Bronze", Finish="Polished", Sound="Deep voluminous clear with pleasant mixture of warmth and assertiveness", Image=Url.Content("~/Images/Hihats/Zultan_Caz.jpg") },
                new Cymbal { Name="Istanbul Agop Xist Dry Dark", Price=238, Size=13, Material="B20 Bronze", Finish="Raw", Sound="Short trashy", Image=Url.Content("~/Images/Hihats/Istanbul_Agop.jpg") },
                new Cymbal { Name="Paiste 2002 Classic", Price=435, Size=15, Material="CuSn8 alloy", Finish="Polished", Sound="Medium bright, full, brilliant", Image=Url.Content("~/Images/Hihats/Paiste_2002Classic.jpg") },
                new Cymbal { Name="Paiste PST3", Price=79, Size=14, Material="Brass", Finish="Natural", Sound="Medium bright, clear, full", Image=Url.Content("~/Images/Hihats/Paiste_PST3.jpg") }
            };

            return View(hihats);
        }

        public IActionResult Crashes()
        {
            var crashes = new List<Cymbal>
            {
                new Cymbal { Name="Zildjian A-Custom", Price=299, Size=16, Material="Cast Bronze", Finish="Brilliant", Sound="Natural, bright", Image=Url.Content("~/Images/Crashes/Zildjian_A.jpg") },
                new Cymbal { Name="Zultan Aja", Price=68, Size=16, Material="B20 Bronze", Finish="Polished", Sound="Loud, full-bodied", Image=Url.Content("~/Images/Crashes/Zultan_Aja.jpg") },
                new Cymbal { Name="Istanbul Agop Xist ION", Price=178, Size=16, Material="Copper/ Tin", Finish="Brilliant", Sound="Trashy, short sustain", Image=Url.Content("~/Images/Crashes/Istanbul_Agop.jpg") },
                new Cymbal { Name="Sabian AAXplosion", Price=365, Size=18, Material="B20 Bronze", Finish="Brilliant", Sound="Clear, clean, defined", Image=Url.Content("~/Images/Crashes/Sabian_AAX.jpg") },
                new Cymbal { Name="Paiste PST7", Price=119, Size=18, Material="CuSn8 Bronze", Finish="Polished", Sound="Traditional", Image=Url.Content("~/Images/Crashes/Paiste_PST7.jpg") },
                new Cymbal { Name="Zultan Q", Price=118, Size=15, Material="B20 Bronze", Finish="High-gloss polished/ Untreated raw", Sound="Full", Image=Url.Content("~/Images/Crashes/Zultan_Q.jpg") },
                new Cymbal { Name="Zildjian K-Custom", Price=398, Size=17, Material="Cast Bronze", Finish="Regular", Sound="Dry, trashy overtones", Image=Url.Content("~/Images/Crashes/Zildjian_K.jpg") },
                new Cymbal { Name="Meinl Byzance", Price=489, Size=20, Material="B20 Bronze", Finish="Extra dry natular", Sound="Thin, fast-decaying with deep basic tone", Image=Url.Content("~/Images/Crashes/Meinl_Byzance.jpg") }
            };

            return View(crashes);
        }

        public IActionResult Rides()
        {
            var rides = new List<Cymbal>
            {
                new Cymbal { Name="Zildjian K-Custom", Price=498, Size=20, Material="Cast Bronze", Finish="Regular", Sound="Dry, warm undertones with trashy dynamic", Image=Url.Content("~/Images/Rides/Zildjian_K.jpg") },
                new Cymbal { Name="Paiste 101", Price=89, Size=20, Material="Brass", Finish="Polished", Sound="Soft, balanced", Image=Url.Content("~/Images/Rides/Paiste_101.jpg") },
                new Cymbal { Name="Sabian HHX Fierce", Price=549, Size=21, Material="Bronze", Finish="Raw", Sound="Rough, dark tone", Image=Url.Content("~/Images/Rides/Sabian_HHX.jpg") },
                new Cymbal { Name="Zultan Raw Jazz", Price=238, Size=22, Material="B20 Bronze", Finish="Non-lathed", Sound="Dark, warm, full", Image=Url.Content("~/Images/Rides/Zultan_RawJazz.jpg") },
                new Cymbal { Name="Paiste \"The Powerslave\"", Price=609, Size=22, Material="B20 Bronze", Finish="Brilliant", Sound="Dark, full, controlled, glassy, deep harmonic wash", Image=Url.Content("~/Images/Rides/Paiste_Reflector.jpg") },
                new Cymbal { Name="Istanbul Mehmet Bl Bell", Price=415, Size=23, Material="B20 Bronze", Finish="Traditional", Sound="Resonant, rich", Image=Url.Content("~/Images/Rides/Istanbul_Mehmet.jpg") },
                new Cymbal { Name="Meinl Byzance Apple", Price=579, Size=24, Material="Cast Bronze", Finish="Traditional", Sound="Earthy with relatively short sustain", Image=Url.Content("~/Images/Rides/Meinl_Byzance.jpg") },
                new Cymbal { Name="Zultan Caz", Price=277, Size=24, Material="B20 Bronze", Finish="Polished", Sound="Full, shimmering harmonic overtones", Image=Url.Content("~/Images/Rides/Zultan_Caz.jpg") },
            };

            return View(rides);
        }

        public IActionResult Hardware()
        {
            var hardware = new List<Hardware>
            {
                new Hardware { Name="DW PDP 700", Price=285, Comprises=new string[] { "2x PDCB710 boom cymbal stand", "1x PDHH713 hi-hat stand", "1x PDSS710 snare stand", "1x PDSP710 single drum pedal" }, Image=Url.Content("~/Images/Hardware/DW_PDP_700.jpg") },
                new Hardware { Name="Mapex HP6005", Price=389, Comprises=new string[] { "2x B600 Cymbal boom stands", "1x H600 Hi-Hat stand", "1x S600 Snare stand", "1x P600 Bass Drum Pedal" }, Image=Url.Content("~/Images/Hardware/Mapex_HP6005.jpg") },
                new Hardware { Name="Sonor HS LT 2000S", Price=469, Comprises=new string[] { "1x HH LT 2000 Hi-hat stands", "1x SS LT 2000 Snare drum stand", "2x MBS LT V2 Mini boom stand", "1x SP 2000 Single bass drum pedal" }, Image=Url.Content("~/Images/Hardware/Sonor_2000S.jpg") },
                new Hardware { Name="Yamaha HW880", Price=698, Comprises=new string[] { "1x HS850 hi-hat stand", "1x SS850 snare stand", "1x FP9500C single pedal", "2x CS865 cymbal boom stand without counterweight" }, Image=Url.Content("~/Images/Hardware/Yamaha_HW880.jpg") },
                new Hardware { Name="Tama HG5WN", Price=795, Comprises=new string[] { "1x HP900PN Iron Cobra power glide single pedal", "1x HS800W Roadpro snare stand", "2x HC83BW Roadpro cymbal boom stand", "1x HH905D Iron Cobra hi-hat stand" }, Image=Url.Content("~/Images/Hardware/Tama_HG5WN.jpg") },
                new Hardware { Name="Pearl HWP-2010", Price=1111, Comprises=new string[] { "2x B-1030 Cymbal boom stands", "1x H-1050 Hi-Hat machine", "1x S-1030 Snare stand", "1x P-2ß5ßC Single bass drum pedal" }, Image=Url.Content("~/Images/Hardware/Pearl_HWP2010.jpg") }
            };

            return View(hardware);
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
