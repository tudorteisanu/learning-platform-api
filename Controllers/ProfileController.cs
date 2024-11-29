
using System.Security.Claims;
using AutoMapper;
using LearningPlatform.DTO;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public ProfileController(IUserService userService, IMapper mapper,  IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetuserProfile()
    {
        var currentUserId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (currentUserId == null) {
            return Unauthorized();
        }
           
        var user = await _userService.GetUserByIdAsync(new Guid(currentUserId));

        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDTO>(user);

        return Ok(userDto);
    }
}
