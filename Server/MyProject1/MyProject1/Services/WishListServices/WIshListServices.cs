using Microsoft.EntityFrameworkCore;
using MyProject.Models.Lists;
using MyProject1.Models;
using MyProject1.Models.Lists;

namespace MyProject1.Services.WishListServices
{
    public class WIshListServices : IWishListServices
    {
        private readonly ApplicationDbContext _context;

        public WIshListServices(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<WishList> CreateWhishListAsync(ApplicationUser user)
        {

            //assign user to new wishlist
            WishList wishList = new WishList()
            {
                ApplicationUser = user,
                 ApplicationUserId = user.Id,   

            };
            await _context.AddAsync(wishList);
            await _context.SaveChangesAsync();

            return wishList;
        }

        public async Task<WishListItem> AddItemToWhishListAync(int realEstateId, int whishListId)
        {
            var wishList = await GetById(whishListId);
            var realEstate = await _context.RealEStates.SingleOrDefaultAsync(p => p.Id == realEstateId);
            WishListItem wishListItem = new WishListItem()
            {
                WishList = wishList,
                RealStatesId = realEstateId,
                WishListId = whishListId,
                RealStates = realEstate,
            };
            await _context.AddAsync(wishListItem);
            await _context.SaveChangesAsync();
            wishList.WishListItems.Add(wishListItem);
            _context.Update(wishList);
            await _context.SaveChangesAsync();
            return wishListItem;
        }

        public async Task<WishList> GetById(int id)
        {
            var whishList = await _context.WishLists.SingleOrDefaultAsync(u => u.WishListId == id);

            return whishList;
        }

        public async Task<IEnumerable<WishListItem>> GetWishListItems(int wishListId)
        {
            var wishList = await GetById(wishListId);
            if (wishList != null)
            {
                return wishList.WishListItems;
            }
            return Enumerable.Empty<WishListItem>();
        }

        public async Task<WishListItem> RemoveAsync(int wishListItemId, int wishListId)
        {
            var whishList = await GetById(wishListId);
            var item = _context.WishListItems.SingleOrDefault(u => u.RealStatesId == wishListItemId);
            whishList.WishListItems.Remove(item);
            await _context.SaveChangesAsync();
            return item;

        }
    }
}
