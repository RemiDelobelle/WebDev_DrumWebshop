namespace DrumWebshop.Models
{
    public class Snare : Product
    {
        public int Diameter { get; set; }
        public double Depth { get; set; }
        public int PlyCount { get; set; }
        public string Material { get; set; }
        public int LugCount { get; set; }
        public string Finish { get; set; }
    }
}
