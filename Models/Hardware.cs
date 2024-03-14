namespace DrumWebshop.Models
{
    public class Hardware: Product
    {
        public ICollection<HwComponent> HwComponents { get; set; }
    }
}
