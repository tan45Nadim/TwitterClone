using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // api/users
        [HttpGet()]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });

            return Ok(userDtos);    
        }
        
        // api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("user not found");
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(userDto);
        }


        // api/users/{id}
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.FirstName) || 
                string.IsNullOrWhiteSpace(req.LastName) || 
                string.IsNullOrWhiteSpace(req.Email))
            {
                return BadRequest("all fields are required");
            }

            var existingUser = _userRepository.GetUserByEmail(req.Email);

            if (existingUser != null)
            {
                return BadRequest("user with this email already exists");
            }

            var newUser = new User
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email
            };

            _userRepository.AddUser(newUser);

            var userDto = new UserDto
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email
            };

            return Ok(userDto);
        }


        // api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserRequest req)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("user not found");
            }

            if (string.IsNullOrWhiteSpace(req.FirstName) || 
                string.IsNullOrWhiteSpace(req.LastName) )
            {
                return BadRequest("all fields are required");
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;

            _userRepository.UpdateUser(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(userDto);
        }

        // api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("user not found");
            }

            _userRepository.DeleteUser(user);

            return Ok(new
            {
                message = "User deleted successfully."
            });
        }
    }
}
