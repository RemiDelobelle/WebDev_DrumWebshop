namespace DrumWebshop.Models
{
    public enum CymbalType
    {
        Hihat, Crash, Ride
    }
    public class Cymbal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public string Material { get; set; }
        public string Finish { get; set; }
        public string Sound { get; set; }
        public string Image { get; set; }
        public CymbalType Type { get; set; }

    }
}
