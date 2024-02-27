namespace DrumWebshop.Models
{
    public class Snare
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Diameter { get; set; }
        public double Depth { get; set; }
        public int PlyCount { get; set; }
        public string Material { get; set; }
        public int LugCount { get; set; }
        public string Finish { get; set; }
        public string Image { get; set; }

        //public Snare(string name, int price, int diameter, double depth, int plyCount, string material, int lugCount, string finish, string image)
        //{
        //    Name = name;
        //    Price = price;
        //    Diameter = diameter;
        //    Depth = depth;
        //    PlyCount = plyCount;
        //    Material = material;
        //    LugCount = lugCount;
        //    Finish = finish;
        //    Image = image;
        //}
    }
}
