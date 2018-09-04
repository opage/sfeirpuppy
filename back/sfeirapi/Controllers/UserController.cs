using Microsoft.AspNetCore.Mvc;
using sfeirapi.Models;
using sfeirapi.Repositories;

namespace sfeirapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        [ProducesResponseType(200)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = _userRepository.AddNewUser(user);
            return CreatedAtAction("AddNewUser", new { id = userId }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_userRepository.ModifyUser(id, user))
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            if (_userRepository.Delete(id))
                return Ok();
            return NotFound();
        }
    }
}
