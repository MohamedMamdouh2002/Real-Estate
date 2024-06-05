
using MyProject1.Models;
using MyProject1.Models.Lists;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models.Lists
{
    public class WishList
    {

        public int WishListId { get; set; }

        public ICollection<WishListItem>? WishListItems { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } // Foreign key to ApplicationUser
        public ApplicationUser ApplicationUser { get; set; } // Navigation property
    
}
}
