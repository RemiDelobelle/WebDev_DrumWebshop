using DrumWebshop.Data;
using DrumWebshop.Models;

namespace DrumWebshop
{
    public class DbInitializer
    {
        public static List<Product> InitializeProducts(DrumContext drumContext)
        {
            var products = new List<Product>()
            {
                new Snare { Name="Pearl Export", Price=119, Diameter=14, Depth=5.5, PlyCount=6, Material="Popular/ Maghony", LugCount=8, Finish="Laminated", Image="~/Images/Snares/Pearl_Export.jpg" },
                new Snare { Name = "DW PDP Walnut", Price=325, Diameter = 14, Depth = 6.5, PlyCount=20, Material = "Walnut", LugCount = 10, Finish="Natural", Image = "~/Images/Snares/DW_PDP_Walnut.jpg" },
                new Snare { Name = "DW Alex González", Price=2390, Diameter = 14, Depth = 6.5, PlyCount=11, Material = "Maple", LugCount = 10, Finish="High-gloss lacquered", Image = "~/Images/Snares/DW_AlexGonzalez.jpg" },
                new Snare { Name = "Sonor Select Jungle", Price=169, Diameter = 10, Depth = 2, PlyCount=9, Material = "Maple", LugCount = 6, Finish="Natural Semi-Gloss", Image = "~/Images/Snares/Sonor_Jungle.jpg" },
                new Snare { Name = "Sonor SSD Benny Grep", Price=888, Diameter = 13, Depth = 5.75, PlyCount=9, Material = "Beech", LugCount = 8, Finish="Satin Scandinavian Birch veneer", Image = "~/Images/Snares/Sonor_SSDBennyG.jpg"     },
                new Snare { Name = "Ludwig Supraphonic", Price=769, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Aluminium", LugCount = 10, Finish="", Image = "~/Images/Snares/Ludwig_Supraphonic.jpg" },
                new Snare { Name = "Yamaha Stage Custom", Price=169, Diameter = 14, Depth = 5.5, PlyCount=0, Material = "Steel", LugCount = 8, Finish="", Image = "~/Images/Snares/Yamaha_StageCustom.jpg" },
                new Snare { Name = "Pearl S1330B", Price=314, Diameter = 13, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = "~/Images/Snares/Pearl_S1330B.jpg" },
                new Snare { Name = "Pearl Fire Cracker", Price=243, Diameter = 10, Depth = 5, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = "~/Images/Snares/Pearl_FireCracker.jpg" },
                new Snare { Name = "Ludwig LB417 Bl Beauty", Price=1035, Diameter = 14, Depth = 6.5, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = "~/Images/Snares/Ludwig_LB417.jpg" },
                new Snare { Name = "Pearl B1330 Piccolo", Price=371, Diameter = 13, Depth = 3, PlyCount=0, Material = "Brass", LugCount = 6, Finish="", Image = "~/Images/Snares/Pearl_B1330Piccolo.jpg" },
                new Snare { Name = "Ludwig Carl Palmer", Price=444, Diameter = 14, Depth = 3.7, PlyCount=0, Material = "Brass", LugCount = 10, Finish="", Image = "~/Images/Snares/Ludwig_CarlPalmer.jpg" },
                new Snare { Name = "Meinl Snare Timbale", Price=155, Diameter = 10, Depth = 3, PlyCount=0, Material = "Steel", LugCount = 6, Finish="", Image = "~/Images/Snares/Meinl_Timbale.jpg" },

                new Shell { Name="DW PDP Concept Classic", Price=1069, Pieces=3, PlyCount=7, Material="Maple", Colour="Natural with walnut hoops", Image="~/Images/Shells/DW_PDP_Concept.jpg" },
                new Shell { Name="Pearl Crystal Beat Rock", Price=1625, Pieces=4, PlyCount=0, Material="Acrylic", Colour="Transparant", Image="~/Images/Shells/Pearl_Clear.jpg" },
                new Shell { Name="Gretsch Renown Studio", Price=1899, Pieces=4, PlyCount=7, Material="Maple", Colour="Vintage Pearl", Image="~/Images/Shells/Gretsch_Renown.jpg" },
                new Shell { Name="Tama Starclassic", Price=2090, Pieces=4, PlyCount=5, Material="Birch", Colour="Satin Sapphire Fade", Image="~/Images/Shells/Tama_Starcl.jpg" },
                new Shell { Name="Mapex Saturn Evo", Price=2899, Pieces=5, PlyCount=8, Material="Walnut", Colour="Brunswick Green", Image="~/Images/Shells/Mapex_SaturnEvo.jpg" },
                new Shell { Name="Ludwig Classic", Price=4399, Pieces=4, PlyCount=7, Material="Maple", Colour="Vintage Black Oyster", Image="~/Images/Shells/Ludwig_Classic.jpg" },
                new Shell { Name="DW Satin Oil", Price=8899, Pieces=6, PlyCount=8, Material="Maple", Colour="Satin Regal Blue", Image="~/Images/Shells/DW_Satin.jpg" },

                new Cymbal { Name="Zildjian A-Series New Beat", Price=459, Size=14, Material="Copper/ Tin", Finish="Regular/ Traditional", Sound="Solid", Image="~/Images/Hihats/Zildjian_A.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Zultan Q", Size=14, Price=198, Material="B20 Bronze", Finish="High-gloss polished/ Untreated raw", Sound="Warm basic tone with assertive dynamic range", Image="~/Images/Hihats/Zultan_Q.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Paiste PSTX Swiss", Price=111, Size=10, Material="Bronze/ Brass", Finish="Slik matte", Sound="Dry assertive", Image="~/Images/Hihats/Paiste_PSTX.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Zultan Caz", Price=218, Size=15, Material="B20 Bronze", Finish="Polished", Sound="Deep voluminous clear with pleasant mixture of warmth and assertiveness", Image="~/Images/Hihats/Zultan_Caz.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Istanbul Agop Xist Dry Dark", Price=238, Size=13, Material="B20 Bronze", Finish="Raw", Sound="Short trashy", Image="~/Images/Hihats/Istanbul_Agop.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Paiste 2002 Classic", Price=435, Size=15, Material="CuSn8 alloy", Finish="Polished", Sound="Medium bright, full, brilliant", Image="~/Images/Hihats/Paiste_2002Classic.jpg", Type=CymbalType.Hihat },
                new Cymbal { Name="Paiste PST3", Price=79, Size=14, Material="Brass", Finish="Natural", Sound="Medium bright, clear, full", Image="~/Images/Hihats/Paiste_PST3.jpg", Type=CymbalType.Hihat },

                new Cymbal { Name="Zildjian A-Custom", Price=299, Size=16, Material="Cast Bronze", Finish="Brilliant", Sound="Natural, bright", Image="~/Images/Crashes/Zildjian_A.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Zultan Aja", Price=68, Size=16, Material="B20 Bronze", Finish="Polished", Sound="Loud, full-bodied", Image="~/Images/Crashes/Zultan_Aja.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Istanbul Agop Xist ION", Price=178, Size=16, Material="Copper/ Tin", Finish="Brilliant", Sound="Trashy, short sustain", Image="~/Images/Crashes/Istanbul_Agop.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Sabian AAXplosion", Price=365, Size=18, Material="B20 Bronze", Finish="Brilliant", Sound="Clear, clean, defined", Image="~/Images/Crashes/Sabian_AAX.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Paiste PST7", Price=119, Size=18, Material="CuSn8 Bronze", Finish="Polished", Sound="Traditional", Image="~/Images/Crashes/Paiste_PST7.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Zultan Q", Price=118, Size=15, Material="B20 Bronze", Finish="High-gloss polished/ Untreated raw", Sound="Full", Image="~/Images/Crashes/Zultan_Q.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Zildjian K-Custom", Price=398, Size=17, Material="Cast Bronze", Finish="Regular", Sound="Dry, trashy overtones", Image="~/Images/Crashes/Zildjian_K.jpg", Type=CymbalType.Crash },
                new Cymbal { Name="Meinl Byzance", Price=489, Size=20, Material="B20 Bronze", Finish="Extra dry natular", Sound="Thin, fast-decaying with deep basic tone", Image="~/Images/Crashes/Meinl_Byzance.jpg", Type=CymbalType.Crash },

                new Cymbal { Name="Zildjian K-Custom", Price=498, Size=20, Material="Cast Bronze", Finish="Regular", Sound="Dry, warm undertones with trashy dynamic", Image="~/Images/Rides/Zildjian_K.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Paiste 101", Price=89, Size=20, Material="Brass", Finish="Polished", Sound="Soft, balanced", Image="~/Images/Rides/Paiste_101.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Sabian HHX Fierce", Price=549, Size=21, Material="Bronze", Finish="Raw", Sound="Rough, dark tone", Image="~/Images/Rides/Sabian_HHX.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Zultan Raw Jazz", Price=238, Size=22, Material="B20 Bronze", Finish="Non-lathed", Sound="Dark, warm, full", Image="~/Images/Rides/Zultan_RawJazz.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Paiste \"The Powerslave\"", Price=609, Size=22, Material="B20 Bronze", Finish="Brilliant", Sound="Dark, full, controlled, glassy, deep harmonic wash", Image="~/Images/Rides/Paiste_Reflector.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Istanbul Mehmet Bl Bell", Price=415, Size=23, Material="B20 Bronze", Finish="Traditional", Sound="Resonant, rich", Image="~/Images/Rides/Istanbul_Mehmet.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Meinl Byzance Apple", Price=579, Size=24, Material="Cast Bronze", Finish="Traditional", Sound="Earthy with relatively short sustain", Image="~/Images/Rides/Meinl_Byzance.jpg", Type=CymbalType.Ride },
                new Cymbal { Name="Zultan Caz", Price=277, Size=24, Material="B20 Bronze", Finish="Polished", Sound="Full, shimmering harmonic overtones", Image="~/Images/Rides/Zultan_Caz.jpg", Type=CymbalType.Ride },

                new Hardware { Name="DW PDP 700", Price=285, Image="~/Images/Hardware/DW_PDP_700.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 2, ProductCode = "PDCB710", Name = "Boom cymbal stand" },
                    new HwComponent { Count = 1, ProductCode = "PDHH713", Name = "Hi-hat stand" },
                    new HwComponent { Count = 1, ProductCode = "PDSS710", Name = "Snare stand" },
                    new HwComponent { Count = 1, ProductCode = "PDSP710", Name = "Single drum pedal" }
                }},
                new Hardware { Name="Mapex HP6005", Price=389, Image="~/Images/Hardware/Mapex_HP6005.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 2, ProductCode = "B600", Name = "Cymbal boom stand" },
                    new HwComponent { Count = 1, ProductCode = "H600", Name = "Hi-Hat stand" },
                    new HwComponent { Count = 1, ProductCode = "S600", Name = "Snare stand" },
                    new HwComponent { Count = 1, ProductCode = "P600", Name = "Bass Drum Pedal" }
                }},
                new Hardware { Name="Sonor HS LT 2000S", Price=469, Image="~/Images/Hardware/Sonor_2000S.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 1, ProductCode = "HH LT 2000", Name = "Hi-hat stand" },
                    new HwComponent { Count = 1, ProductCode = "SS LT 2000", Name = "Snare drum stand" },
                    new HwComponent { Count = 2, ProductCode = "MBS LT V2", Name = "Mini boom stand" },
                    new HwComponent { Count = 1, ProductCode = "SP 2000", Name = "Single bass drum pedal" }
                }},
                new Hardware { Name="Yamaha HW880", Price=698, Image="~/Images/Hardware/Yamaha_HW880.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 1, ProductCode = "HS850", Name = "Hi-hat stand" },
                    new HwComponent { Count = 1, ProductCode = "SS850", Name = "Snare stand" },
                    new HwComponent { Count = 1, ProductCode = "FP9500C", Name = "Single pedal" },
                    new HwComponent { Count = 2, ProductCode = "CS865", Name = "Cymbal boom stand" }
                }},
                new Hardware { Name="Tama HG5WN", Price=795, Image="~/Images/Hardware/Tama_HG5WN.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 1, ProductCode = "HP900PN", Name = "Iron Cobra power glide single pedal" },
                    new HwComponent { Count = 1, ProductCode = "HS800W", Name = "Roadpro snare stand" },
                    new HwComponent { Count = 2, ProductCode = "HC83BW", Name = "Roadpro cymbal boom stand" },
                    new HwComponent { Count = 1, ProductCode = "HH905D", Name = "Iron Cobra hi-hat stand" }
                }},
                new Hardware { Name="Pearl HWP-2010", Price=1111, Image="~/Images/Hardware/Pearl_HWP2010.jpg", HwComponents = new List<HwComponent>
                {
                    new HwComponent { Count = 2, ProductCode = "B-1030", Name = "Cymbal boom stand" },
                    new HwComponent { Count = 1, ProductCode = "H-1050", Name = "Hi-Hat machine" },
                    new HwComponent { Count = 1, ProductCode = "S-1030", Name = "Snare stand" },
                    new HwComponent { Count = 1, ProductCode = "P-2ß5ßC", Name = "Single bass drum pedal" }
                }}
            };
            return products;
        }
    }
}
