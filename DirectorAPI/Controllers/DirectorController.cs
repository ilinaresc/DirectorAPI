using DirectorDomain.Core.Entities;
using DirectorDomain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectorAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        public DirectorController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var favorites = await _directorRepository.GetAll();
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Director director)
        {
            var result = await _directorRepository.Insert(director);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Director director)
        {
            if (id != director.Id) return BadRequest();
            var result = await _directorRepository.Update(director);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _directorRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
