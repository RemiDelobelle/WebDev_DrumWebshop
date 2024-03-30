using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using DrumWebshop.Models;

namespace DrumWebshop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public bool IsCheckedOut { get; set; } = false;

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        public CartItem()
        { }

        public CartItem(Product product, int quantity, string userId)
        {
            Product = product;
            Quantity = quantity;
            UserId = userId;
        }
    }
}
