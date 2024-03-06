namespace DrumWebshop.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public ICollection<HwComponent> HwComponents { get; set; }
    }
}
