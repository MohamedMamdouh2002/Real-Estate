using Microsoft.AspNetCore.Mvc;
using MyProject.Models.realstates;
using MyProject.Services.ReaEStateTypeServices;
using MyProject1.Dtos;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEStateTypeController : ControllerBase
    {
        private readonly IReaEStateTypeServices _service;

        public RealEStateTypeController(IReaEStateTypeServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var realEStateType = await _service.GetAll();
            return Ok(realEStateType);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var realEStateType = await _service.GetById(id);
            if (realEStateType == null)
                return NotFound("There are no realEStateType with this id ");

            return Ok(realEStateType);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] RealEStateTypeDto realEStateType)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.ErrorCount);
            RealEStateType realEStateType2 = new()
            {
                Name = realEStateType.Name
            };
            await _service.Add(realEStateType2);
            return Ok(realEStateType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RealEStateType realEStateType)
        {
            var eStateType = await _service.GetById(id);
            if (realEStateType == null)
                return NotFound("There are no realEStateType to update it ");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            eStateType.Name = realEStateType.Name;
            _service.Update(eStateType);
            return Ok(eStateType);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var realEStateType = await _service.GetById(id);
            if (realEStateType == null)
                return NotFound($"There are no state with Id :{id} ");
            _service.Delete(realEStateType);

            return Ok(realEStateType);
        }
    }
}
