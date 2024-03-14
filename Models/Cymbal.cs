namespace DrumWebshop.Models
{
    public enum CymbalType
    {
        Hihat, Crash, Ride
    }
    public class Cymbal: Product
    {
        public int Size { get; set; }
        public string Material { get; set; }
        public string Finish { get; set; }
        public string Sound { get; set; }
        public CymbalType Type { get; set; }
    }
}
