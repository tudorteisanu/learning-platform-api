using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using AutoMapper;
using LearningPlatform.DTO;
using Microsoft.AspNetCore.Authorization;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class AchievementsController : ControllerBase
{
    private readonly IAchievementsService _achievementsService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public AchievementsController(
        IAchievementsService achievementsService, 
        IMapper mapper,
        IUserService userService
        )
    {
        _achievementsService = achievementsService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Achievement>>> GetAchievements()
    {
        var userId = _userService.GetCurrentUserId();

        if (userId == Guid.Empty) {
            return NotFound();
        }
        
        var achievements = await _achievementsService.GetUserAchievementsAsync(userId);

        if (achievements == null)
        {
            return NotFound();
        }

        var achievementDto = achievements.Select(user => _mapper.Map<AchievementDTO>(user));

        return Ok(achievementDto);
    }
}
