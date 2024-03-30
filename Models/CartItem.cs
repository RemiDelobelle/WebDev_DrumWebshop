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
        public Product Product { get; set; } // Reference to the product
        public bool IsCheckedOut { get; set; } = false;

        public string UserId { get; set; } // Foreign key for the user
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } // Navigation property for the user

        public CartItem()
        { }

        // Constructor to initialize the cart item with a product
        public CartItem(Product product, int quantity, string userId)
        {
            Product = product;
            Quantity = quantity;
            UserId = userId;
        }
    }
}
