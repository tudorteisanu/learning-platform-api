
using AutoMapper;
using LearningPlatform.DTO;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDTO>(user);

        return Ok(userDto);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddUser(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var createdUser = await _userService.RegisterUserAsync(user);

        return Ok(_mapper.Map<UserDTO>(createdUser));
    }
}
