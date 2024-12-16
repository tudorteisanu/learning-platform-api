using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using LearningPlatform.DTO;
using AutoMapper;

namespace LearningPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized(new{ Message ="Invalid credentials." });
        }

        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var success = await _authService.RegisterAsync(user);

        if (!success)
        {
            return BadRequest(new { Message = "Registration failed." });
        }

        return Ok(new { Message = "Registration successful." });
    }
}

