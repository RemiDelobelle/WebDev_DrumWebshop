namespace DrumWebshop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public CartItem()
        { }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
