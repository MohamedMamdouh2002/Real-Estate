using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Services.AmenitiesServices;
using MyProject.Services.CompoundServices;
using MyProject1.Dtos;
using MyProject1.Services.AmenitiesCompoundServices;

namespace MyProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundAmenitiesController : ControllerBase
    {
        private readonly IAmenitiesCompoundServices _services;
        private readonly ICompoundServices _compoundservices;
        private readonly IMapper _mapper;
        private readonly IAmentiesServicces _amentiesServicces;

        public CompoundAmenitiesController(IAmenitiesCompoundServices services, IMapper mapper, IAmentiesServicces amentiesServicces, ICompoundServices compoundservices)
        {
            _services = services;
            _mapper = mapper;
            _amentiesServicces = amentiesServicces;
            _compoundservices = compoundservices;
        }

        [HttpGet("{compoundId}")]
        public async Task<IActionResult> GetCompoundAmenities(int compoundId)
        {
            var amenities = await _services.GetAmenitiesOfCompound(compoundId);
            if (amenities == null)
                return NotFound("thes compound doesnot have amenities ");

            List<CompoundAmenitiesDto> dto = new List<CompoundAmenitiesDto>();
            foreach (var amen in amenities)
            {
                CompoundAmenitiesDto compoundAmenities = new()
                {
                    AmenitiesId = amen.AmenitiesId,
                    AmenitiesName = amen.Amenities.Name,
                    CompoundName = amen.Compound.Name
                };
                dto.Add(compoundAmenities);
            }

            return Ok(dto);

        }
        [HttpPost("{compoundId}/{AmenitiesId}")]
        public async Task<IActionResult> AddCompoundAmenities
            (int compoundId, int AmenitiesId)
        {
            var result = await _services.AddAmenitiesOfCompound(compoundId, AmenitiesId);
            return Ok(result);
        }
    }
}
