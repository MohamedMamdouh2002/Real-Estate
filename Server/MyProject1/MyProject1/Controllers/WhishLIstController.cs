using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject1.Services.WishListServices;

namespace MyProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhishLIstController : ControllerBase
    {
        private readonly IWishListServices _wishListService;

        public WhishLIstController(IWishListServices wishListService)
        {
            _wishListService = wishListService;
        }
        [HttpPost]
        public IActionResult AddItemToWhishListAync(int realEstateId, int wishListId)
        {
            var wishList = _wishListService.AddItemToWhishListAync(realEstateId, wishListId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(wishList);
        }
        [HttpGet]
        public IActionResult GetWishListItemsAync(int wishListId)
        {
            var wishListItems = _wishListService.GetWishListItems(wishListId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(wishListItems);
        }
        [HttpDelete]
        public IActionResult DeleteItemFromWishListAsync(int realEstateId, int wishListId)
        {
            var wishListItems = _wishListService.RemoveAsync(realEstateId, wishListId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(wishListItems);
        }
    }
}
