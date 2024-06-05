using Microsoft.AspNetCore.Identity;
using MyProject.Models.Lists;

//using MyProject.Models.Lists;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FullName { get; set; }


        [MinLength(11), MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Range(21, 150)]
        public int Age { get; set; }


        public int WishListId { get; set; } // Foreign key to WishList
        public WishList WishList { get; set; } // Navigation property
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}