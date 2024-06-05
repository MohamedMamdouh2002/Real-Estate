using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models.RealStates;
using MyProject.Services.DeveloperSerices;
using MyProject.Services.Shared;
using MyProject1.Dtos.CompoundDtos;
using MyProject1.Dtos.DeveloperDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperServices _services;
        private readonly IMapper _mapper;

        public DeveloperController(IDeveloperServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allDevelopers = await _services.GetAll();
            var Data = _mapper.Map<IEnumerable<DeveloperReturnDto>>(allDevelopers);
            foreach (var item in allDevelopers)
            {
                foreach (var data in Data)
                {
                    data.LogoURL = "https://localhost:7203" + data.LogoURL;


                }
            }
            return Ok(Data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloperByIdAsync(int id)
        {
            var developer = _services.GetById(id);
            if (developer == null)
                return NotFound($"There are no developer with this id:{id} ");
            var data = _mapper.Map<DeveloperReturnDto>(developer);
            data.LogoURL = "https://localhost:7203" + developer.LogoURL;
            return Ok(data);
        }
        [HttpGet("GetByDeveloperName")]
        public async Task<IActionResult> GetDevelopersByNameAsync([FromQuery] string developerName)
        {
            var SearchItem = developerName.Replace(" ", "").Trim().ToLower();
            var developer = await _services.GetByName(SearchItem);
            if (developer == null)
                return NotFound($"There are no developer with this name:{developerName} ");
            var Data = _mapper.Map<IEnumerable<DeveloperReturnDto>>(developer);
            foreach (var item in developer)
            {
                foreach (var data in Data)
                {
                    data.LogoURL = "https://localhost:7203" + item.LogoURL;


                }
            }
            return Ok(Data);
        }


        [HttpPost("AddDeveloper")]
        public async Task<IActionResult> AddDevelopersAsync([FromForm] DeveloperDto dto)
        {
            if (dto.Logo == null)
                return BadRequest("Picture is required!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.ErrorCount);
            var developer = await _services.Add(dto);
            return Ok(developer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] DeveloperDto dto)
        {
            var developer = _services.GetById(id);
            if (developer == null)
                return NotFound("There are no developer to update it ");

            if (dto.Logo == null)
                return NotFound("Picture is not Found");

            if (!ModelState.IsValid)
                return BadRequest(ModelState.ErrorCount);
            var developer1 = _services.Update(dto);
            var result = _mapper.Map<DeveloperReturnDto>(developer1);
            result.LogoURL = "https://localhost:7203" + result.LogoURL;
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var developer = _services.GetById(id);
            if (developer == null)
                return NotFound($"There are no developer with Id :{id} ");
            _services.Delete(developer);
            var data = _mapper.Map<DeveloperDto>(developer);

            return Ok(data);
        }
    }
}
