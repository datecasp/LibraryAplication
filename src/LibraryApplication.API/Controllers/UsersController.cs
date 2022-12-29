using AutoMapper;
using LibraryApplication.API.Dtos.User;
using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using LibraryApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : MainController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper,
                                    IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            
            return Ok(_mapper.Map<IEnumerable<UserAvailabilityDto>>(users));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(_mapper.Map<UserAvailabilityDto>(user));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(UserAddDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<User>(userDto);
            var userResult = _userService.Add(user);

            if (userResult == null) return BadRequest();

            return Ok(_mapper.Map<UserResultDto>(userResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            bool result = await _userService.Update(user);

            if (result)
            {
                return Ok($"User {id} updated.");
            }

            return BadRequest();
        }


        [HttpPut("userAvailability/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAvailability(int id, User user)
        {
            if (user == null) return NotFound();
            
            if (id != user.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            user.IsActive = !user.IsActive;

            bool result = await _userService.Update(user);

            if (result)
            {
                return Ok($"User {id} updated.");
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound();

            var result = await _userService.Remove(user);

            if (!result) return BadRequest();

            return Ok($"User {id} removed");
        }
    }
}
