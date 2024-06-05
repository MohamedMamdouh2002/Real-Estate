using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos;
using MyProject.Dtos.Amenities;
using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using MyProject.Services.AmenitiesServices;
using MyProject.Services.Shared;
using MyProject1.Dtos.Amenities;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmentiesServicces _service;
        private readonly IMapper _mapper;

        public AmenitiesController(IAmentiesServicces service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var amenities = await _service.GetAll();
            foreach (var amenitie in amenities)
            {
                amenitie.ImgURL = "https://localhost:7203" + amenitie.ImgURL;
            }

            return Ok(amenities);
        }

        [HttpGet("{CompoundId}")]
        public async Task<IActionResult> GetByRealEStateId(int CompoundId)
        {
            var amenities = await _service.GetByCompoundId(CompoundId);
            if (amenities == null)
                return NotFound($" there are no amenities for This CompoundId :{CompoundId}");
            var data = _mapper.Map<IEnumerable<AmenitiesReturnDto>>(amenities);
            foreach (var amenitie in data)
            {
                amenitie.ImgURL = "https://localhost:7203" + amenitie.ImgURL;
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AmenitiesDto amenitiesDto)
        {
            Amenities amenities = new Amenities()
            {
                Name = amenitiesDto.Name,
            };
            if (amenitiesDto == null)
                return BadRequest("Please enter Amenities ");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var amenities1 = await _service.Add(amenities, amenitiesDto.Img);
            amenities1.ImgURL = "https://localhost:7203" + amenities1.ImgURL;


            return Ok(amenities1);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] AmenitiesDto dto)
        {
            var amenities = await _service.GetById(id);
            if (amenities == null)
                return NotFound("There are no amenities to update it ");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            amenities.Name = dto.Name;
            var amenitie = _service.update(amenities);
            amenitie.ImgURL = "https://localhost:7203" + amenitie.ImgURL;

            return Ok(amenitie);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var amenities = await _service.GetById(id);
            if (amenities == null)
                return NotFound($"There are no amenities with Id :{id} ");
            _service.Delete(amenities);
            var data = _mapper.Map<AmenitiesReturnDto>(amenities);

            return Ok(data);
        }
    }
}
