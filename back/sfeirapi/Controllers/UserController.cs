using Microsoft.AspNetCore.Mvc;
using sfeirapi.Models;
using sfeirapi.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace sfeirapi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = await _userRepository.AddNewUser(user);
            return CreatedAtAction("AddNewUser", new { id = userId }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _userRepository.ModifyUser(id, user))
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _userRepository.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
