
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.Photo;
using MyProject.Models.RealStates;
using MyProject.Services.PhotoServices;
using MyProject.Services.Shared;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoServices _services;

        public PhotoController(IPhotoServices services)
        {
            _services = services;
        }

        [HttpGet("{RealEStateId}")]
        public async Task<IActionResult> GetByRealEStateIdAsync(int RealEStateId)
        {
            var Photos = await _services.GetByRealEStateId(RealEStateId);
            if (Photos == null)
                return NotFound($"ther are no photos for this RealEState");
            foreach (var photo in Photos)
            {
                photo.ImgURL = "https://localhost:7203" + photo.ImgURL;
            }

            return Ok(Photos);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] PhotoDto photoDto)
        {
            Photo photo = new Photo()
            {
                RealEStateId = photoDto.RealEStateId,
            };
            bool IsValid = PictureValidation.IsPictureValid(photoDto.Picture);
            if (!IsValid)
                return BadRequest("Picture is not valid!");

            if (!ModelState.IsValid)
                return BadRequest("Picture is not valid!");
            var image = await _services.Add(photo, photoDto.Picture);
            image.ImgURL = "https://localhost:7203" + image.ImgURL;
            return Ok(image);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync([FromBody] PhotoDto photoDto, int PhotoId)
        //{
        //    var photo = await _services.GetById(PhotoId);
        //    bool IsValid = PictureValidation.IsPictureValid(photoDto.Picture);
        //    if (!IsValid)
        //        return BadRequest("Picture is not valid!");

        //    if (!ModelState.IsValid)
        //        return BadRequest("Picture is not valid!");

        //    _services.Update(photo);
        //    return Ok(photo);
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int photoId)
        {
            var photo = await _services.GetById(photoId);
            if (photo == null)
                return NotFound($" there are no photo with this id:{photoId}");
            _services.Delete(photo);
            return Ok(photo);
        }
    }
}
