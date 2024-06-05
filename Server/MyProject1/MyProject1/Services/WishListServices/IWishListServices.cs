using MyProject.Models.Lists;
using MyProject1.Models;
using MyProject1.Models.Lists;

namespace MyProject1.Services.WishListServices
{
    public interface IWishListServices
    {
        Task<WishList> GetById(int id);
        Task<WishListItem> RemoveAsync(int wishListItemId, int wishListId);
        Task<IEnumerable<WishListItem>> GetWishListItems(int wishListId); Task<WishList> CreateWhishListAsync(ApplicationUser user);
        Task<WishListItem> AddItemToWhishListAync(int realEstateId, int whishListId);
    }
}
