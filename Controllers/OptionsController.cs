using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Models;
using LearningPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using LearningPlatform.DTO;
using AutoMapper;
using LearningPlatform.Data;

namespace LearningPlatform.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class OptionsController : ControllerBase {
    private readonly IOptionsService _optionsService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public OptionsController(
        IOptionsService optionsService,
         IMapper mapper,
         AppDbContext context
         ) {
        _optionsService = optionsService;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet("{questionId}")]
    public async Task<ActionResult<IEnumerable<Option>>> GetOptionsByQuestionId(Guid questionId) {
        return Ok(await _optionsService.GetOptionsByQuestionId(questionId));
    }

    [HttpPost]
    public async Task<ActionResult<Option>> CreateOption(OptionDTO optionDto) {
        var option = _mapper.Map<Option>(optionDto);
        return Ok(await _optionsService.CreateOption(option));
    }

    [HttpDelete("{questionId}")]
    public async Task<ActionResult> CreateOption(Guid questionId) {
        var isDeleted = await _optionsService.DeleteQuestion(questionId);

        if (!isDeleted) {
            return NotFound("Failed to delete question");
        }

        return Ok();
    }

     [HttpPatch("{optionId}")]
    public async Task<IActionResult> CreateLesson(Guid optionId, OptionPatchDTO dto)
    {
        var option = await _context.Options.FindAsync(optionId);

        if (option == null) {
            return NotFound("Option not found.");
        }
        
         _mapper.Map(dto, option);
        await _context.SaveChangesAsync();
        return Ok(option);
    }
}