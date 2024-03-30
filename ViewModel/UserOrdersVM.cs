using System.Collections.Generic;
using DrumWebshop.Models;
using Microsoft.AspNetCore.Identity;
using DrumWebshop.Models;

namespace DrumWebshop.ViewModel
{
    public class UserOrdersVM
    {
        public List<IdentityUser> Users { get; set; }
        public List<CartItem> Orders { get; set; }
    }
}
