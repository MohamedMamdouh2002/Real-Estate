
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Dtos.Photo;
using MyProject.Models.RealStates;
using MyProject.Services.CompoundServices;
using MyProject.Services.Shared;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Models.RealStates;
using MyProject1.Services.AmenitiesCompoundServices;
using MyProject1.Services.ImageServices;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundController : ControllerBase
    {
        private readonly ICompoundServices _compoundServices;
        private readonly IMapper _mapper;
        private readonly IImageServices<Compound> _imageServices;
        private readonly IAmenitiesCompoundServices _amenitiesCompound;

        public CompoundController(ICompoundServices compoundServices, IMapper mapper, IImageServices<Compound> imageServices, IAmenitiesCompoundServices amenitiesCompound)
        {
            _compoundServices = compoundServices;
            _mapper = mapper;
            _imageServices = imageServices;
            _amenitiesCompound = amenitiesCompound;
        }
        [HttpGet("{DeveloperId}/GetByDevelopers")]
        public async Task<IActionResult> GetByDeveloperIdAsync(int DeveloperId)
        {
            var compounds = await _compoundServices.GetByDeveloperId(DeveloperId);
            if (compounds == null)
                return NotFound("there are no compounds related to rhis developer");
            return Ok(compounds);
        }
        [HttpGet("GetByDevelopersName")]
        public async Task<IActionResult> GetByDeveloperNameAsync([FromQuery] string DeveloperName)
        {
            var SearchItem = DeveloperName.Replace(" ", string.Empty).Trim().ToLower();
            var compounds = await _compoundServices.GetByDeveloperName(SearchItem);
            if (compounds == null)
                return NotFound("there are no compounds related to rhis developer");

            return Ok(compounds);
        }
        [HttpGet("GetByCompoundName")]
        public async Task<IActionResult> GetByCompoundNameAsync([FromQuery] string compoundName)
        {
            var SearchItem = compoundName.Replace(" ", string.Empty).Trim().ToLower();
            var compounds = await _compoundServices.GetByCompoundName(SearchItem);
            if (compounds == null)
                return NotFound("there are no compounds by this name");

            return Ok(compounds);
        }

        [HttpPost("AddCompound")]
        public async Task<IActionResult> Add([FromForm] CompoundDto dto)
        {
            if (dto == null)
                return NotFound("There are no compound to Add it ");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var compound = await _compoundServices.Add(dto);

            return Ok(compound);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var compounds = _compoundServices.GetAll();
            if (compounds == null)
                return NotFound("there are no compounds related to rhis developer");

            return Ok(compounds);
        }


        [HttpGet("{id}/GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var compound = await _compoundServices.GetByIdReturnDto(id);
            if (compound == null)
                return NotFound($"There are no Compound by that id :{id} ");

            return Ok(compound);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] CompoundDto dto)
        {


            var compound = await _compoundServices.Update(id, dto);
            if (compound == null)
            {
                return NotFound("There are no compound with this id");
            }
            return Ok(compound);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var compound = _compoundServices.GetById(id);
            if (compound == null)
                return NotFound($"There are no Compound with Id :{id} ");
            var data = _mapper.Map<CompoundReturnDto>(compound);
            _compoundServices.Delete(compound);
            return Ok(data);
        }

    }
}
